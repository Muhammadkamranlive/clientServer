using AutoMapper;
using CourseMicroSerivce.Domain;
using CourseMicroSerivce.Models.AutoMapperDTOS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.ServicessAccessLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController :GenericController<Person,PersonDTOS>
    {
        public PersonController(IGenericService<Person> genericService, IMapper mapper):base(genericService,mapper)
        {
            
        }
    }
}
