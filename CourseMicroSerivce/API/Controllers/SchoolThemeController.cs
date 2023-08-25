using AutoMapper;
using CourseMicroSerivce.Core.ServicessAccessLayer.Contracts.DomainContracts;
using CourseMicroSerivce.Core.ServicessAccessLayer.Implementations;
using CourseMicroSerivce.Domain.TeacherPortal;
using CourseMicroSerivce.Models.TeacherPortal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Controllers;

namespace CourseMicroSerivce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolThemeController : ParentController<SchoolThemes, SchoolThemesModel>
    {
        private readonly ISchoolThemes_Service _schoolThemesService;
        private readonly IMapper _mapper;
        private readonly ISchoolSubjects_Service _subjectService;
        private readonly ISchoolClasses_Service _classService;
        private readonly IClassesSessions_Service _sessionService;
        private readonly IPermission_Service _permissionService;
        public SchoolThemeController
        (
         ISchoolThemes_Service Service,
         IMapper mapper,
         ISchoolSubjects_Service schoolSubjects,
         ISchoolClasses_Service schoolClasses_Service,
         IClassesSessions_Service sessionService,
         IPermission_Service permissionService
        ) : base(Service, mapper)
        {
            _schoolThemesService = Service;
            _mapper = mapper;
            _subjectService = schoolSubjects;
            _classService = schoolClasses_Service;
            _sessionService = sessionService;
            _permissionService = permissionService;
        }

        public override async Task<IActionResult> GetAll()
        {



            try
            {
                var result = await _schoolThemesService.GetAll();
                result = result.Where(x => x.status == "Live").ToList();
                var clientResult = _mapper.Map<IList<SchoolThemesModel>>(result);
                return Ok(clientResult);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message + e.InnerException?.Message);
            }

        }

        [HttpGet]
        [Route("GetTeacherThemesLive")]
        public async Task<IActionResult> GetTeacherThemesLive(string Uid)
        {

            try
            {
                var classes = await _classService.GetAll();
                var session = await _sessionService.GetAll();
                var subject = await _subjectService.GetAll();
                var themes = await _schoolThemesService.GetAll();
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
                       themes,
                       (c) => new { id = c.su.Id },
                       (t) => new { id = t.SubjectId },
                       (c, t) => new { c.c, c.su, c.s, t }
                     )
                      .Join
                     (
                      permission,
                      (s) => new { Id = s.su.Id, },
                      (p) => new { Id = p.SubjectId.Value, },
                      (s, p) => new { s.s, s.c, s.su, s.t, p }
                     )

                     .Where
                     (
                      x => x.t.status == "Live" &&
                      x.p.TeacherId == Uid

                     )
                     .Select
                     (
                      x => new
                      {
                          Id = x.t.Id,
                          Name = x.t.Name,
                          image = x.t.image,
                          status = x.t.status,
                          subjectId = x.t.SubjectId,
                          className = x.c.Name,
                          subjectName = x.su.Name,
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
        [Route("GetTeacherThemesDraft")]
        public async Task<IActionResult> GetTeacherThemesDraft(string Uid)
        {

            try
            {
                var classes = await _classService.GetAll();
                var session = await _sessionService.GetAll();
                var subject = await _subjectService.GetAll();
                var themes = await _schoolThemesService.GetAll();
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
                       themes,
                       (c) => new { id = c.su.Id },
                       (t) => new { id = t.SubjectId },
                       (c, t) => new { c.c, c.su, c.s, t }
                     )
                      .Join
                     (
                      permission,
                      (s) => new { Id = s.su.Id, },
                      (p) => new { Id = p.SubjectId.Value, },
                      (s, p) => new { s.s, s.c, s.su, s.t, p }
                     )

                     .Where
                     (
                      x => x.t.status == "Draft" &&
                      x.p.TeacherId == Uid

                     )
                     .Select
                     (
                      x => new
                      {
                          Id = x.t.Id,
                          Name = x.t.Name,
                          image = x.t.image,
                          status = x.t.status,
                          subjectId = x.t.SubjectId,
                          className = x.c.Name,
                          subjectName = x.su.Name,
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

        //admin Area 
        [HttpGet]
        [Route("GethemesDraft")]
        public async Task<IActionResult> GethemesDraft()
        {

            try
            {
                var classes = await _classService.GetAll();
                var session = await _sessionService.GetAll();
                var subject = await _subjectService.GetAll();
                var themes = await _schoolThemesService.GetAll();
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
                       themes,
                       (c) => new { id = c.c.Id },
                       (t) => new { id = t.Id },
                       (c, t) => new { c.c, c.su, c.s, t }
                     )
                     .Where
                     (
                      x => x.t.status == "Draft"
                     )
                     .Select
                     (
                      x => new
                      {
                          Id = x.t.Id,
                          Name = x.t.Name,
                          image = x.t.image,
                          status = x.t.status,
                          subjectId = x.t.SubjectId,
                          className = x.c.Name,
                          subjectName = x.su.Name,
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
        [Route("Gethemes")]
        public async Task<IActionResult> Gethemes()
        {

            try
            {
                var classes = await _classService.GetAll();
                var session = await _sessionService.GetAll();
                var subject = await _subjectService.GetAll();
                var themes = await _schoolThemesService.GetAll();
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
                       themes,
                       (c) => new { id = c.c.Id },
                       (t) => new { id = t.Id },
                       (c, t) => new { c.c, c.su, c.s, t }
                     )
                     .Where
                     (
                      x => x.t.status == "Live"
                     )
                     .Select
                     (
                      x => new
                      {
                          Id = x.t.Id,
                          Name = x.t.Name,
                          image = x.t.image,
                          status = x.t.status,
                          subjectId = x.t.SubjectId,
                          className = x.c.Name,
                          subjectName = x.su.Name,
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
