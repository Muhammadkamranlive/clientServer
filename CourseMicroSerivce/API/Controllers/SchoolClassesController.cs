using AutoMapper;
using CourseMicroSerivce.Core.ServicessAccessLayer.Contracts.DomainContracts;
using CourseMicroSerivce.Domain.TeacherPortal;
using CourseMicroSerivce.Models.TeacherPortal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Controllers;

namespace CourseMicroSerivce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolClassesController : ParentController<SchoolClasses, SchoolClassesModel>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolClasses_Service _service;
        private readonly IClassesSessions_Service _sessionService;
        public SchoolClassesController
        (
         ISchoolClasses_Service  Service, 
         IMapper                 mapper,
         IClassesSessions_Service sessionService

        ) : base(Service, mapper)
        {
            _mapper         = mapper;
            _service        = Service;
            _sessionService = sessionService;
        }


        [HttpGet]
        [Route("Getdetails")]
        public  async Task<IActionResult> Getdetails()
        {



            try
            {
                var result   = await _service.GetAll();
                var sessions = _mapper.Map<IList<ClassSessionModel>>(await _sessionService.GetAll()) ;
                var data=result.
                             Join
                             (
                                 sessions,
                                 (c)=>   new {id=c.SesssionId},
                                 (s)=>   new {id=s.Id},
                                 (c,s)=> new {c,s}
                             )
                             .Where(x=>x.c.status=="Live" && x.s.status=="Live")
                             .Select
                             ( x=> new
                             {
                                 x.c.Id,
                                 x.c.Name,
                                 x.c.status,
                                 x.c.SesssionId,
                                 x.c.image,
                                 x.s.SessionStart,
                                 x.s.SessionEnd,

                             }
                              
                             )
                            .ToList();

                
                return Ok(data);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message + e.InnerException?.Message);
            }

        }


        [HttpGet]
        [Route("GetDraft")]
        public  async Task<IActionResult> GetDraft()
        {



            try
            {
                var result = await _service.GetAll();
                var sessions = _mapper.Map<IList<ClassSessionModel>>(await _sessionService.GetAll());
                var data = result.
                             Join
                             (
                                 sessions,
                                 (c) => new { id = c.SesssionId },
                                 (s) => new { id = s.Id },
                                 (c, s) => new { c, s }
                             )
                             .Where(x => x.c.status == "Draft")
                             .Select
                             (x => new
                             {
                                 x.c.Id,
                                 x.c.Name,
                                 x.c.status,
                                 x.c.SesssionId,
                                 x.c.image,
                                 x.s.SessionStart,
                                 x.s.SessionEnd,

                             }

                             )
                            .ToList();


                return Ok(data);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message + e.InnerException?.Message);
            }

        }


    }
}
