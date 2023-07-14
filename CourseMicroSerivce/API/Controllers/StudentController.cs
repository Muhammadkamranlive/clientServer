using AutoMapper;
using CourseMicroSerivce.Domain;
using CourseMicroSerivce.Models.AutoMapperDTOS;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.ServicessAccessLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = ("Student"))]
    public class StudentController :GenericController<Students,StudentDTOS>
    {
        public StudentController(IStudentService genericService, IMapper mapper) 
            :base(genericService, mapper)
        {

        }
    }
}
