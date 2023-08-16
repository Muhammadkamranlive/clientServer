using CourseMicroSerivce.Domain.AuthenticationModels;
using CourseMicroSerivce.Models.AutoMapperDTOS;
using Microsoft.AspNetCore.Identity;
using Project.ServicessAccessLayer.Implementations.AuthContractsImplementations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.ServicessAccessLayer.Contracts.AuthContracts
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> RegisterTeacher(TeacherDto teacherDto);
        Task<IEnumerable<IdentityError>> RegisterStudent(StudentDto studentDto);
        Task<IEnumerable<IdentityError>> RegisterAdmin(AdminDto adminDto);
        Task<AuthResponseDto> Login(LoginDto loginDto);
        Task<dynamic> GetList();
        Task<int> GetCountuser();


    }
}
