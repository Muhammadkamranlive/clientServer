using AutoMapper;
using CourseMicroSerivce.Core.ServicessAccessLayer.Contracts.DomainContracts;
using CourseMicroSerivce.Core.ServicessAccessLayer.Implementations;
using CourseMicroSerivce.Domain.TeacherPortal;
using CourseMicroSerivce.Models.TeacherPortal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Controllers;
using System.Security.Cryptography.Xml;

namespace CourseMicroSerivce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolCoursesController : ParentController<SchoolCourses, SchoolCoursesModel>
    {
        private readonly ISchoolCourses_Service _schoolCourse;
        private readonly ISchoolChapters_Service _chapterService;
        private readonly ISchoolSubjects_Service _subjectService;
        private readonly ISchoolClasses_Service _classService;
        private readonly IClassesSessions_Service _sessionService;
        private readonly ISchoolThemes_Service _schoolThemesService;
        private readonly ICoursePosts_Service _coursePostsService;
        public SchoolCoursesController
        (
            ISchoolCourses_Service  Service, IMapper mapper,
            ISchoolChapters_Service  chapterService,
            ISchoolSubjects_Service  schoolSubjects_Service,
            IClassesSessions_Service sessionSerivice,
            ISchoolClasses_Service   classes_Service,
            ISchoolThemes_Service    schoolThemes_Service,
            ICoursePosts_Service     coursePostsService
        ) : base(Service, mapper)
        {
            _chapterService      = chapterService;
            _subjectService      = schoolSubjects_Service;
            _classService        = classes_Service;
            _sessionService      = sessionSerivice;
            _schoolThemesService = schoolThemes_Service;
            _schoolCourse        = Service;
            _coursePostsService  = coursePostsService; 
        }

        [HttpGet]
        [Route("getCourse")]
        public async Task<IActionResult> getCourse()
        {

            try
            {
                var classes  = await _classService.GetAll();
                var session  = await _sessionService.GetAll();
                var subject  = await _subjectService.GetAll();
                var themes   = await _schoolThemesService.GetAll();
                var chapters = await _chapterService.GetAll();
                var course   = await _schoolCourse.GetAll();
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
                     .Join
                      (
                       course,
                       (chap)=>new {id=chap.chap.Id},
                       (course)=> new {id=course.ChapterId},
                       (chap,cous)=> new {chap.s,chap.c,chap.su,chap.t,chap.chap,cous}
                      )
                     .Where
                     (
                      x => x.chap.status == "Live"
                     )
                     .Select
                     (
                      x => new
                      {
                          Id                 = x.cous.Id,
                          CourseName         = x.cous.Name,
                          CourseImage        = x.cous.image,
                          CourseStatus       = x.cous.status,
                          CourseType         = x.cous.CourseType,
                          ChapterId          = x.chap.Id,
                          chapterName        = x.chap.Name,
                          chapterstatus      = x.chap.status,
                          themeId            = x.chap.ThemeId,
                          themeName          = x.t.Name,
                          subjectId          = x.t.SubjectId,
                          className          = x.c.Name,
                          subjectName        = x.su.Name,
                          session            = x.s.SessionStart + " to " + x.s.SessionEnd,

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
        [Route("getCourseDetail")]
        public async Task<IActionResult> getCourseDetail(int id)
        {

            try
            {
                var classes    = await _classService.GetAll();
                var session    = await _sessionService.GetAll();
                var subject    = await _subjectService.GetAll();
                var themes     = await _schoolThemesService.GetAll();
                var chapters   = await _chapterService.GetAll();
                var course     = await _schoolCourse.GetAll();
                var CoursePost = await _coursePostsService.GetAll(); 
                var subjects   = 
                    classes.
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
                      (c)     => new { id = c.c.Id },
                      (su)    => new { id = su.ClassId },
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
                     .Join
                      (
                       course,
                       (chap) => new { id = chap.chap.Id },
                       (course) => new { id = course.ChapterId },
                       (chap, cous) => new { chap.s, chap.c, chap.su, chap.t, chap.chap, cous }
                      )
                      .Join
                      (
                       CoursePost,
                       (c)=> new {id=c.cous.Id},
                       (p)=> new {id=p.SchoolCourseId},
                       (c,p)=> new {c.chap,c.t,c.su,c.cous,c.s,c.c,p}
                      )
                     .Where
                     (
                      x => x.cous.status == "Live" && x.cous.Id==id
                     )
                     .Select
                     (
                      x => new
                      {
                          Id            = x.p.Id,
                          CourseName    = x.cous.Name,
                          CourseImage   = x.cous.image,
                          CourseStatus  = x.cous.status,
                          CourseType    = x.cous.CourseType,
                          ChapterId     = x.chap.Id,
                          chapterName   = x.chap.Name,
                          chapterstatus = x.chap.status,
                          themeId       = x.chap.ThemeId,
                          themeName     = x.t.Name,
                          subjectId     = x.t.SubjectId,
                          className     = x.c.Name,
                          subjectName   = x.su.Name,
                          Title         = x.p.Title,
                          description   = x.p.Description,
                          CourseDescStatus  = x.p.status,
                          session       = x.s.SessionStart + " to " + x.s.SessionEnd,

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
        [Route("getCoursewithChapters")]
        public async Task<IActionResult> getCoursewithChapters(int id)
        {

            try
            {
                var classes = await _classService.GetAll();
                var session = await _sessionService.GetAll();
                var subject = await _subjectService.GetAll();
                var themes = await _schoolThemesService.GetAll();
                var chapters = await _chapterService.GetAll();
                var course = await _schoolCourse.GetAll();
               
                var subjects =
                    classes.
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
                     .Join
                      (
                       course,
                       (chap) => new { id = chap.chap.Id },
                       (course) => new { id = course.ChapterId },
                       (chap, cous) => new { chap.s, chap.c, chap.su, chap.t, chap.chap, cous }
                      )
                     
                     .Where
                     (
                      x => x.cous.status == "Live" && x.cous.CourseType== "Course" && x.chap.Id == id
                     )
                     .GroupBy(
                        x => new
                        {
                            ChapterId     = x.chap.Id,
                            ChapterName   = x.chap.Name,
                            ChapterStatus = x.chap.status,
                            ThemeId       = x.t.Id,
                            ThemeName     = x.t.Name,
                            SubjectId     = x.t.SubjectId,
                            ClassName     = x.c.Name,
                            SubjectName   = x.su.Name,
                            Session       = x.s.SessionStart + " to " + x.s.SessionEnd,
                           
                            
                            
                            
                        },
                        (key, group) => new
                        {
                            ChapterId   = key.ChapterId,
                            ChapterName  = key.ChapterName,
                            ChapterStatus = key.ChapterStatus,
                            ThemeId     = key.ThemeId,
                            ThemeName   = key.ThemeName,
                            SubjectId   = key.SubjectId,
                            ClassName   = key.ClassName,
                            SubjectName = key.SubjectName,
                            Session     = key.Session,
                            Courses = group.Select(g => new
                            {
                                Id = g.cous.Id,
                                CourseName = g.cous.Name,
                                CourseImage = g.cous.image,
                                CourseStatus = g.cous.status,
                                CourseType = g.cous.CourseType,
                               
                              
                               
                            })
                        })
                    .ToList();

                return Ok(subjects);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message + e.InnerException?.Message);
            }

        }


        [HttpGet]
        [Route("getExecisewithChapters")]
        public async Task<IActionResult> getExecisewithChapters(int id)
        {

            try
            {
                var classes = await _classService.GetAll();
                var session = await _sessionService.GetAll();
                var subject = await _subjectService.GetAll();
                var themes = await _schoolThemesService.GetAll();
                var chapters = await _chapterService.GetAll();
                var course = await _schoolCourse.GetAll();

                var subjects =
                    classes.
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
                     .Join
                      (
                       course,
                       (chap) => new { id = chap.chap.Id },
                       (course) => new { id = course.ChapterId },
                       (chap, cous) => new { chap.s, chap.c, chap.su, chap.t, chap.chap, cous }
                      )

                     .Where
                     (
                      x => x.cous.status == "Live" && x.cous.CourseType == "Exercise" && x.chap.Id == id
                     )
                     .GroupBy(
                        x => new
                        {
                            ChapterId = x.chap.Id,
                            ChapterName = x.chap.Name,
                            ChapterStatus = x.chap.status,
                            ThemeId = x.t.Id,
                            ThemeName = x.t.Name,
                            SubjectId = x.t.SubjectId,
                            ClassName = x.c.Name,
                            SubjectName = x.su.Name,
                            Session = x.s.SessionStart + " to " + x.s.SessionEnd,




                        },
                        (key, group) => new
                        {
                            ChapterId = key.ChapterId,
                            ChapterName = key.ChapterName,
                            ChapterStatus = key.ChapterStatus,
                            ThemeId = key.ThemeId,
                            ThemeName = key.ThemeName,
                            SubjectId = key.SubjectId,
                            ClassName = key.ClassName,
                            SubjectName = key.SubjectName,
                            Session = key.Session,
                            Courses = group.Select(g => new
                            {
                                Id = g.cous.Id,
                                CourseName = g.cous.Name,
                                CourseImage = g.cous.image,
                                CourseStatus = g.cous.status,
                                CourseType = g.cous.CourseType,



                            })
                        })
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
