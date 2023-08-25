using AutoMapper;
using CourseMicroSerivce.Domain.AuthenticationModels;
using CourseMicroSerivce.Models.AutoMapperDTOS;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Project.ServicessAccessLayer.Contracts.AuthContracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Project.ServicessAccessLayer.Implementations.AuthContractsImplementations
{
    public class AuthManager : IAuthManager
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AuthManager(IMapper mapper, UserManager<ApplicationUser> userManager, IConfiguration configuration, RoleManager<IdentityRole> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
            _roleManager = roleManager;
        }

        public async Task<AuthResponseDto> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            IList<string> roles = await _userManager.GetRolesAsync(user);
            if (user == null)
            {
                return new AuthResponseDto { Message = "User not found." };
            }

            bool isValidUser = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if (!isValidUser)
            {
                return new AuthResponseDto { Message = "Invalid credentials." };
            }

            if (await _userManager.IsInRoleAsync(user, "Teacher"))
            {
                var teacher = (Teacher)user;

                if (teacher.ExpirationDate < DateTime.UtcNow)
                {
                    return new AuthResponseDto { Message = "Login expired for teacher." };
                }
            }
            else if (await _userManager.IsInRoleAsync(user, "Student"))
            {
                var student = (Student)user;

                if (student.endDate < DateTime.UtcNow)
                {
                    return new AuthResponseDto { Message = "Login expired for student." };
                }
            }
            // Add more conditions for other roles if needed

            var token = await GenerateToken(user);
            
            return new AuthResponseDto
            {
                Token   = token,
                UserId  = user.Id,
                Message = "Success"
            };
        }



        public async Task<IEnumerable<IdentityError>> RegisterTeacher(TeacherDto teacherDto)
        {
            var teacher             = new Teacher();
            teacher.UserName        = teacherDto.UserName;
            teacher.Email           = teacherDto.Email;
            teacher.PasswordHash    = teacherDto.Password;
            teacher.FirstName       = teacherDto.FirstName;
            teacher.LastName        = teacherDto.LastName;
            teacher.Image           = teacherDto.Image;
            teacher.AddressLine1    = teacherDto.AddressLine1;
            teacher.ZipCode         = teacherDto.ZipCode;
            teacher.City            = teacherDto.City;
            teacher.Country         = teacherDto.Country;
            teacher.ExpirationDate  = teacherDto.ExpirationDate;
            teacher.startingDate    = teacherDto.StartingDate;
            teacher.language        = teacherDto.Language;
            teacher.ClassId         = teacherDto.ClassId; 
            teacher.SessionId       = teacherDto.SessionId;

            var result = await _userManager.CreateAsync(teacher, teacherDto.Password);
            if (result.Succeeded)
            {
                // Check if the "Teacher" role exists, and create it if not
                var roleExists = await _roleManager.RoleExistsAsync("Teacher");
                if (!roleExists)
                {
                    await _roleManager.CreateAsync(new IdentityRole("Teacher"));
                }

                // Add the user to the "Teacher" role
                await _userManager.AddToRoleAsync(teacher, "Teacher");
            }

            return result.Errors;
        }

        public async Task<IEnumerable<IdentityError>> RegisterStudent(StudentDto studentDto)
        {
            var teacher = new Student();

            teacher.UserName         = studentDto.UserName;
            teacher.Email            = studentDto.Email;
            teacher.PasswordHash     = studentDto.Password;
            teacher.FirstName        = studentDto.FirstName;
            teacher.LastName         = studentDto.LastName;
            teacher.Image            = studentDto.Image;
            teacher.AddressLine1     = studentDto.AddressLine1;
            teacher.ZipCode          = studentDto.ZipCode;
            teacher.City             = studentDto.City;
            teacher.Country          = studentDto.Country;
            teacher.endDate          = DateTime.UtcNow.AddMonths(1);
            teacher.startDate        = DateTime.UtcNow;
            teacher.speakingLanguage = studentDto.Language;
            teacher.ClassId          = studentDto.ClassId;
            teacher.SessionId        = studentDto.SessionId;

            var result = await _userManager.CreateAsync(teacher, studentDto.Password);
            if (result.Succeeded)
            {
                // Check if the "Student" role exists, and create it if not
                var roleExists = await _roleManager.RoleExistsAsync("Student");
                if (!roleExists)
                {
                    await _roleManager.CreateAsync(new IdentityRole("Student"));
                }

                // Add the user to the "Student" role
                await _userManager.AddToRoleAsync(teacher, "Student");
            }

            return result.Errors;
        }

        public async Task<IEnumerable<IdentityError>> RegisterAdmin(AdminDto adminDto)
        {
            var admin = _mapper.Map<Admin>(adminDto);
            admin.UserName = adminDto.Email;

            var result = await _userManager.CreateAsync(admin, adminDto.PasswordHash);
            if (result.Succeeded)
            {
                // Check if the "Administrator" role exists, and create it if not
                var roleExists = await _roleManager.RoleExistsAsync("Administrator");
                if (!roleExists)
                {
                    await _roleManager.CreateAsync(new IdentityRole("Administrator"));
                }

                // Add the user to the "Administrator" role
                await _userManager.AddToRoleAsync(admin, "Administrator");
            }

            return result.Errors;
        }
        private async Task<string> GenerateToken(ApplicationUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();

            var userClaims = await _userManager.GetClaimsAsync(user);

            var claims = new List<Claim>
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim("uid", user.Id),
            }
            .Union(userClaims)
            .Union(roleClaims);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JwtSettings:DurationInMinutes"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<dynamic> GetList()
        {
         
                var users =  _userManager.Users.ToList();

            // Exclude users with roles "Admin" and "Student"
            var filteredUsers = users.Where(u => !_userManager.IsInRoleAsync(u, "Administrator").Result &&
                                                 !_userManager.IsInRoleAsync(u, "Student").Result)
                                     .ToList();

            return filteredUsers.ToList();

        }

        public async Task<int> GetCountuser()
        {

            var users = _userManager.Users.ToList();

            var filteredUsers = users.Where(u => !_userManager.IsInRoleAsync(u, "Administrator").Result &&
                                                 !_userManager.IsInRoleAsync(u, "Student").Result)
                                     .ToList();

            return filteredUsers.ToList().Count();

        }
    }

}
