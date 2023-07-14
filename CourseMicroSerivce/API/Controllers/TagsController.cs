using AutoMapper;
using CourseMicroSerivce.Domain;
using CourseMicroSerivce.Models.AutoMapperDTOS;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.ServicessAccessLayer.Contracts;
using Project.ServicessAccessLayer.Contracts.DomainContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = ("Teacher"))]
    public class TagsController :GenericController<Tags,TagsDTO>
    {
        public TagsController(ITagsService genericService,IMapper mapper):base(genericService,mapper)
        {

        }
    }
}
