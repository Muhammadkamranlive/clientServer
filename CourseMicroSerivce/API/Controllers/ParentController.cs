using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Project.ServicessAccessLayer.Contracts;


namespace Project.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class ParentController<T,AutoMapperEntity> : ControllerBase where T: class where AutoMapperEntity :class 
    {
        
        private readonly IMapper _mapper;
        public IBase_Service<T> genericService { get; set; }
        public ParentController(IBase_Service<T> genericService,IMapper mapper)
        {
            _mapper = mapper;
           this.genericService = genericService;
      
           
        }

        [HttpPost]
        public virtual async Task<IActionResult> Create(AutoMapperEntity autoMapperEntity)
        {
            

            try
            {
                var clientData = _mapper.Map<T>(autoMapperEntity);
                await genericService.InsertAsync(clientData);
                await genericService.CompleteAync();
                var message = "Data Inserted Successfully for "+ typeof(T)?.Name;
                return Content($"{{ \"message\": \"{message}\" }}", "application/json");
            
            }
            catch (Exception e)
            {

                throw new Exception(e.Message+e.InnerException?.Message);
            }
          
        }
        [HttpGet]
       
        
        public virtual async Task<IActionResult> GetAll()
        {



            try
            {
                var result = await genericService.GetAll();
                var clientResult = _mapper.Map<IList<AutoMapperEntity>>(result);
                return Ok(clientResult);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message + e.InnerException?.Message);
            }
           
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {

            try
            {
                var result = await genericService.Get(id);
                var clientResult = _mapper.Map<AutoMapperEntity>(result);
                return Ok(clientResult);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message + e.InnerException?.Message);
            }
           
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {

            try
            {
                var result = await genericService.Delete(id);
                await genericService.CompleteAync();
                return Ok(result);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message + e.InnerException?.Message);
            }
           
        }

        [HttpPut]
        public async Task<IActionResult> Update(AutoMapperEntity autoMapperEntity)
        {
            try
            {
                var result = _mapper.Map<T>(autoMapperEntity);
                genericService.UpdateRecord(result);
                var update = await genericService.CompleteAync();
                return Ok(update);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message+e.InnerException?.Message);
            }



        }
       
    }
}
