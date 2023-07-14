using System;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using Project.ServicessAccessLayer.Contracts.AuthContracts;
using CourseMicroSerivce.Models;
using Project.ServicessAccessLayer.Implementations.AuthContractsImplementations;
using CourseMicroSerivce.Models.AutoMapperDTOS;

namespace Project.Controllers.AuthenticationControllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
       
        private readonly IMapper mapper;
        private readonly ILogger<AuthController> logger;
        private readonly IAuthManager authManager;
        public AuthController(IMapper mapper,ILogger<AuthController> logger,IAuthManager authManager)
        {
          
            this.mapper = mapper;
            this.logger = logger;
            this.authManager = authManager;

        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Register([FromBody] ApplicationUserDTO apiUserDto)
        {
            var errors = await authManager.Register(apiUserDto);
            if (errors.Any())
            {
                foreach (var error in errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(errors);
            }
            return Ok("User Registered Successfully");
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Login([FromBody] LoginDto loginDto)
        {
            var authResponse = await authManager.Login(loginDto);
            if (authResponse == null)
            {
                return Unauthorized();
            }
            return Ok(authResponse);
        }
    }

   
}
