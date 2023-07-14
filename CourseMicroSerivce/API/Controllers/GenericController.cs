using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using CourseMicroSerivce;
using Project.ServicessAccessLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class GenericController<T,AutoMapperEntity> : ControllerBase where T: class where AutoMapperEntity :class 
    {
        
        private readonly IMapper _mapper;
        public IGenericService<T> genericService { get; set; }
        public GenericController(IGenericService<T> genericService,IMapper mapper)
        {
            _mapper = mapper;
           this.genericService = genericService;
      
           
        }

        [HttpPost]
        public async Task<IActionResult> Create(AutoMapperEntity autoMapperEntity)
        {
           
                var clientData = _mapper.Map<T>(autoMapperEntity);
                await genericService.InsertAsync(clientData);
                await genericService.CompleteAync();
                return Ok(clientData);
          
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
          
           
               
                var listOfObjects = await genericService.GetAll();
                var clientResult = _mapper.Map<List<AutoMapperEntity>>(listOfObjects);
                return Ok(clientResult);
           
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
          
                var result = await genericService.Get(id);
                var clientResult = _mapper.Map<AutoMapperEntity>(result);
                return Ok(clientResult);
           
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
           
                var result = await genericService.Delete(id);
                await genericService.CompleteAync();
                return Ok(result);
           
        }

        [HttpPut]
        public async Task<IActionResult> Update(AutoMapperEntity autoMapperEntity)
        {
            var result = _mapper.Map<T>(autoMapperEntity);
            genericService.UpdateRecord(result);
            var update = await genericService.CompleteAync();
            return Ok(update);



        }
       
    }
}
