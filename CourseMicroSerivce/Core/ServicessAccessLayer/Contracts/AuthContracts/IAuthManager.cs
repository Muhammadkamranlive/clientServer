using CourseMicroSerivce.Models.AutoMapperDTOS;
using Microsoft.AspNetCore.Identity;
using Project.ServicessAccessLayer.Implementations.AuthContractsImplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.ServicessAccessLayer.Contracts.AuthContracts
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> Register(ApplicationUserDTO userDto);
        Task<AuthResponseDto> Login(LoginDto loginDto);


    }
}
