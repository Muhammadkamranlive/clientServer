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
    public class SchoolChaptersController : ParentController<SchoolChapters, SchoolChaptersModel>
    {
        private readonly IMapper                  _mapper;
        private readonly ISchoolChapters_Service  _chapterService;
        private readonly ISchoolSubjects_Service  _subjectService;
        private readonly ISchoolClasses_Service   _classService;
        private readonly IClassesSessions_Service _sessionService;
        private readonly ISchoolThemes_Service _schoolThemesService;
        public SchoolChaptersController
        (
          
          IMapper mapper,
          ISchoolChapters_Service Service,
          ISchoolSubjects_Service schoolSubjects_Service,
          IClassesSessions_Service sessionSerivice,
          ISchoolClasses_Service classes_Service,
          ISchoolThemes_Service schoolThemes_Service
        ) : base(Service, mapper)
        {
            _chapterService = Service;
            _subjectService = schoolSubjects_Service;
            _classService = classes_Service;
            _sessionService = sessionSerivice;
            _schoolThemesService = schoolThemes_Service;
        }

        [HttpGet]
        [Route("getChapters")]
        public async Task<IActionResult> getChapters()
        {

            try
            {
                var classes  = await _classService.GetAll();
                var session  = await _sessionService.GetAll();
                var subject  = await _subjectService.GetAll();
                var themes   = await _schoolThemesService.GetAll();
                var chapters = await _chapterService.GetAll(); 
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
                       (su) => new { id = su.su.Id },
                       (t) => new { id = t.SubjectId },
                       (su, t) => new { su.c, su.su, su.s, t }
                     )
                     .Join
                     (
                      chapters,
                      (th)=> new { id = th.t.Id},
                      (chap)=> new {id=chap.ThemeId},
                      (th,chap)=> new {th.c,th.su,th.s,th.t,chap}
                      )
                     .Where
                     (
                      x => x.chap.status == "Live"
                     )
                     .Select
                     (
                      x => new
                      {
                          Id          = x.chap.Id,
                          Name        = x.chap.Name,
                          status      = x.chap.status,
                          themeId     = x.chap.ThemeId,
                          themeName   =x.t.Name,
                          subjectId   = x.t.SubjectId,
                          className   = x.c.Name,
                          subjectName = x.su.Name,
                          session     = x.s.SessionStart + " to " + x.s.SessionEnd,

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
        [Route("getChaptersDraft")]
        public async Task<IActionResult> getChaptersDraft()
        {

            try
            {
                var classes = await _classService.GetAll();
                var session = await _sessionService.GetAll();
                var subject = await _subjectService.GetAll();
                var themes = await _schoolThemesService.GetAll();
                var chapters = await _chapterService.GetAll();
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
                       (su) => new { id = su.su.Id },
                       (t) => new { id = t.SubjectId },
                       (su, t) => new { su.c, su.su, su.s, t }
                     )
                     .Join
                     (
                      chapters,
                      (th) => new { id = th.t.Id },
                      (chap) => new { id = chap.ThemeId },
                      (th, chap) => new { th.c, th.su, th.s, th.t, chap }
                      )
                     .Where
                     (
                      x => x.chap.status == "Draft"
                     )
                     .Select
                     (
                      x => new
                      {
                          Id = x.chap.Id,
                          Name = x.chap.Name,
                          status = x.chap.status,
                          themeId = x.chap.ThemeId,
                          themeName = x.t.Name,
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
        [Route("getthemeChapters")]
        public async Task<IActionResult> getthemeChapters(int id)
        {

            try
            {
                var classes = await _classService.GetAll();
                var session = await _sessionService.GetAll();
                var subject = await _subjectService.GetAll();
                var themes = await _schoolThemesService.GetAll();
                var chapters = await _chapterService.GetAll();
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
                       (su) => new { id = su.su.Id },
                       (t) => new { id = t.SubjectId },
                       (su, t) => new { su.c, su.su, su.s, t }
                     )
                     .Join
                     (
                      chapters,
                      (th) => new { id = th.t.Id },
                      (chap) => new { id = chap.ThemeId },
                      (th, chap) => new { th.c, th.su, th.s, th.t, chap }
                      )
                     .Where
                     (
                      x => x.chap.status == "Live" && x.su.Id==id
                     )
                     .GroupBy
                     (
                            x => new
                            {
                                ThemeId = x.t.Id,
                                ThemeName = x.t.Name,
                                className=x.c.Name,
                                classId=x.c.Id,
                                subjectName=x.su.Name, 
                                subjectId=x.su.Id,
                                session=x.s.Id,
                                sessionName=x.s.SessionStart+" to "+x.s.SessionEnd,
                            },
                            (key, group) => new
                            {
                                ThemeId = key.ThemeId,
                                ThemeName = key.ThemeName,
                                key.className,
                                key.classId,
                                key.subjectId,
                                key.subjectName,
                                key.session,
                                Chapters = group.Select(g => new
                                {
                                    ChapterId     = g.chap.Id,
                                    ChapterName   = g.chap.Name,
                                    ChapterStatus = g.chap.status,
                                    chaptersImage = g.chap.image     
                                })
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
