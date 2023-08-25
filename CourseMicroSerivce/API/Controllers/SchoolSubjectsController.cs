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
    public class SchoolSubjectsController : ParentController<SchoolSubjects, SchoolSubjectsModel>
    {
        private readonly ISchoolSubjects_Service _subjectService;
        private readonly IMapper _mapper;
        private readonly ISchoolClasses_Service _classService;
        private readonly IClassesSessions_Service _sessionService;
        private readonly IPermission_Service _permissionService;
        public SchoolSubjectsController
        (
         ISchoolSubjects_Service Service,
         ISchoolClasses_Service ClassService,
         IClassesSessions_Service SessionService,
         IMapper mapper,
         IPermission_Service pm

        ) : base(Service, mapper)
        {
            _subjectService = Service;
            _mapper = mapper;
            _classService = ClassService;
            _sessionService = SessionService;
            _permissionService = pm;
        }

        public override async Task<IActionResult> GetAll()
        {



            try
            {
                var result = await _subjectService.GetAll();
                result = result.Where(x => x.Status == "Live").ToList();
                var clientResult = _mapper.Map<IList<SchoolSubjectsModel>>(result);
                return Ok(clientResult);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message + e.InnerException?.Message);
            }

        }


        [HttpGet]
        [Route("GetClassDetails")]
        public async Task<IActionResult> GetClassDetails()
        {

            try
            {
                var classes = await _classService.GetAll();
                var session = await _sessionService.GetAll();
                var subject = await _subjectService.GetAll();

                var subjects = classes.
                     Join
                     (
                                  session,
                                  (c) => new { id = c.SesssionId },
                                  (s) => new { id = s.Id },
                                  (c, s) => new { c, s }
                     )
                     .Join
                     (
                      subject,
                      (c) => new { id = c.c.Id },
                      (su) => new { id = su.ClassId },
                      (c, su) => new { c.c, c.s, su }
                     )
                     .Where
                     (
                      x => x.su.Status == "Live"
                     )
                     .Select
                     (
                      x => new
                      {
                          Id = x.su.Id,
                          Name = x.su.Name,
                          image = x.su.image,
                          status = x.su.Status,
                          classId = x.su.ClassId,
                          className = x.c.Name,
                          session = x.s.SessionStart + " to " + x.s.SessionEnd,

                      }
                     )
                     .ToList();

                return Ok(subjects);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message + e.InnerException?.Message);
            }

        }

        [HttpGet]
        [Route("GetSubjectDraft")]
        public async Task<IActionResult> GetSubjectDraft()
        {

            try
            {
                var classes = await _classService.GetAll();
                var session = await _sessionService.GetAll();
                var subject = await _subjectService.GetAll();

                var subjects = classes.
                     Join
                     (
                                  session,
                                  (c) => new { id = c.SesssionId },
                                  (s) => new { id = s.Id },
                                  (c, s) => new { c, s }
                     )
                     .Join
                     (
                      subject,
                      (c) => new { id = c.c.Id },
                      (su) => new { id = su.ClassId },
                      (c, su) => new { c.c, c.s, su }
                     )
                     .Where
                     (
                      x => x.su.Status == "Draft"
                     )
                     .Select
                     (
                      x => new
                      {
                          Id = x.su.Id,
                          Name = x.su.Name,
                          image = x.su.image,
                          status = x.su.Status,
                          classId = x.su.ClassId,
                          className = x.c.Name,
                          session = x.s.SessionStart + " to " + x.s.SessionEnd,

                      }
                     )
                     .ToList();

                return Ok(subjects);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message + e.InnerException?.Message);
            }

        }


        [HttpGet]
        [Route("teacherGetSubjectsLive")]
        public async Task<IActionResult> teacherGetSubjectsLive(string userId)
        {

            try
            {
                var classes = await _classService.GetAll();
                var session = await _sessionService.GetAll();
                var subject = await _subjectService.GetAll();
                var permission = await _permissionService.GetAll();
                var subjects = classes.
                     Join
                     (
                                  session,
                                  (c) => new { id = c.SesssionId },
                                  (s) => new { id = s.Id },
                                  (c, s) => new { c, s }
                     )
                     .Join
                     (
                      subject,
                      (c) => new { id = c.c.Id },
                      (su) => new { id = su.ClassId },
                      (c, su) => new { c.c, c.s, su }
                     )
                     .Join
                     (
                      permission,
                      (s) => new { Id = s.su.Id },
                      (p) => new { Id = p.SubjectId.Value },
                      (s, p) => new { s.s, s.c, s.su, p }
                     )
                     .Where
                     (
                      x => x.su.Status == "Live"
                      && x.p.TeacherId == userId
                     )
                     .Select
                     (
                      x => new
                      {
                          Id = x.su.Id,
                          Name = x.su.Name,
                          image = x.su.image,
                          status = x.su.Status,
                          classId = x.su.ClassId,
                          className = x.c.Name,
                          session = x.s.SessionStart + " to " + x.s.SessionEnd,

                      }
                     )
                     .ToList();

                return Ok(subjects);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message + e.InnerException?.Message);
            }

        }

        [HttpGet]
        [Route("teacherGetSubjectsDraft")]
        public async Task<IActionResult> teacherGetSubjectsDraft(string userId)
        {

            try
            {
                var classes = await _classService.GetAll();
                var session = await _sessionService.GetAll();
                var subject = await _subjectService.GetAll();
                var permission = await _permissionService.GetAll();
                var subjects = classes.
                     Join
                     (
                                  session,
                                  (c) => new { id = c.SesssionId },
                                  (s) => new { id = s.Id },
                                  (c, s) => new { c, s }
                     )
                     .Join
                     (
                      subject,
                      (c) => new { id = c.c.Id },
                      (su) => new { id = su.ClassId },
                      (c, su) => new { c.c, c.s, su }
                     )
                     .Join
                     (
                      permission,
                      (s) => new { Id = s.su.Id },
                      (p) => new { Id = p.SubjectId.Value },
                      (s, p) => new { s.s, s.c, s.su, p }
                     )
                     .Where
                     (
                      x => x.su.Status == "Draft"
                      && x.p.TeacherId == userId
                     )
                     .Select
                     (
                      x => new
                      {
                          Id = x.su.Id,
                          Name = x.su.Name,
                          image = x.su.image,
                          status = x.su.Status,
                          classId = x.su.ClassId,
                          className = x.c.Name,
                          session = x.s.SessionStart + " to " + x.s.SessionEnd,

                      }
                     )
                     .ToList();

                return Ok(subjects);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message + e.InnerException?.Message);
            }

        }



    }
}
