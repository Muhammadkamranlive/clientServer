using AutoMapper;
using CourseMicroSerivce.Domain;
using CourseMicroSerivce.Models.AutoMapperDTOS;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Project.ServicessAccessLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = ("Teacher"))]
    public class CategoryController :GenericController<Category,CategoryDTO>
    {
      
        public CategoryController(ICategoryService genericService, IMapper mapper):base( genericService,mapper)
        {
          
        }
    }
}
