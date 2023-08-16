
using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using Project.ServicessAccessLayer.Contracts.AuthContracts;

using CourseMicroSerivce.Models.AutoMapperDTOS;
using CourseMicroSerivce.Domain.AuthenticationModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Identity;

namespace CourseMicroSerivce.API.AuthAPI
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IMapper mapper;
        private readonly ILogger<AuthController> logger;
        private readonly IAuthManager authManager;
        public AuthController(IMapper mapper, ILogger<AuthController> logger, IAuthManager authManager)
        {

            this.mapper = mapper;
            this.logger = logger;
            this.authManager = authManager;

        }

        [HttpPost]
        [Route("registerStudent")]
     
        public async Task<ActionResult> registerStudent([FromBody] StudentDto apiUserDto)
        {
            IList<IdentityError> errors = (IList<IdentityError>)await authManager.RegisterStudent(apiUserDto);
            if (errors.Any())
            {
                foreach (var error in errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(errors.Select(x => x.Description).FirstOrDefault());
            }
            var successResponse = new SuccessResponse
            {
                Message = "User Registered Successfully"
            };
            return Ok(successResponse);
        }

        [HttpPost]
        [Route("registerTeacher")]
       
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = ("Administrator"))]
        public async Task<ActionResult> RegisterTeacher([FromBody] TeacherDto apiUserDto)
        {
            IList<IdentityError> errors = (IList<IdentityError>)await authManager.RegisterTeacher(apiUserDto);
            if (errors.Any())
            {
                foreach (var error in errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(errors.Select(x=>x.Description).FirstOrDefault());
            }
            var successResponse = new SuccessResponse
            {
                Message = "User Registered Successfully"
            };
            return Ok(successResponse);
        }

        [HttpPost]
        [Route("registerAdmin")]
       
        public async Task<ActionResult> RegisterAdmin([FromBody] AdminDto apiUserDto)
        {
            IList<IdentityError> errors = (IList<IdentityError>)await authManager.RegisterAdmin(apiUserDto);
            if (errors.Any())
            {
                foreach (var error in errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(errors.Select(x => x.Description).FirstOrDefault());
            }
            var successResponse = new SuccessResponse
            {
                Message = "User Registered Successfully"
            };
            return Ok(successResponse);
        }

        [HttpPost]
        [Route("login")]
      
        public async Task<ActionResult> Login([FromBody] LoginDto loginDto)
        {
            AuthResponseDto authResponse = await authManager.Login(loginDto);
            if (authResponse.UserId == null)
            {
                return Unauthorized(new { message = "Invalid credentials." });
            }
            return Ok(authResponse);
        }



        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = ("Administrator"))]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await authManager.GetList();

            return Ok(users);
        }



    }


}
