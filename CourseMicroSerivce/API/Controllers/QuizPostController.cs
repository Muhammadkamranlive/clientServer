using AutoMapper;
using CourseMicroSerivce.Core.ServicessAccessLayer.Contracts.DomainContracts;
using CourseMicroSerivce.Domain.TeacherPortal;
using CourseMicroSerivce.Models.TeacherPortal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.Controllers;

namespace CourseMicroSerivce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizPostController : ParentController<QuizPosts, QuizPostsModel>
    {
        private readonly IQuizPosts_Service         quizService;
        private readonly ISchoolChapters_Service   _chapterService;
        private readonly ISchoolSubjects_Service   _subjectService;
        private readonly ISchoolClasses_Service    _classService;
        private readonly IClassesSessions_Service  _sessionService;
        private readonly ISchoolThemes_Service     _schoolThemesService;
        private readonly IPermission_Service       _permissionService;

        public QuizPostController
        (
          IQuizPosts_Service       Service,
          IMapper                  mapper,
          ISchoolChapters_Service  chapterService,
          ISchoolSubjects_Service  schoolSubjects_Service,
          IClassesSessions_Service sessionSerivice,
          ISchoolClasses_Service   classes_Service,
          ISchoolThemes_Service    schoolThemes_Service,
          IPermission_Service      pmService

        ) : base(Service, mapper)
        {
              quizService        = Service;
            _chapterService      = chapterService;
            _subjectService      = schoolSubjects_Service;
            _classService        = classes_Service;
            _sessionService      = sessionSerivice;
            _schoolThemesService = schoolThemes_Service;
            _permissionService   = pmService;
        }

        [HttpPost]
        [Route("AddQuiz")]
        public  async Task<IActionResult> AddQuiz(QuizDto autoMapperEntity)
        {


            try
            {
                var clientData = new QuizPosts()
                {
                    Title = autoMapperEntity.Title,
                    status = autoMapperEntity.Status,
                    chapterId = autoMapperEntity.chapterId,
                    questions = JsonConvert.SerializeObject(autoMapperEntity.Questions)
                };
                await quizService.InsertAsync(clientData);
                await quizService.CompleteAync();
                var message = "Data Inserted Successfully for " ;
                return Content($"{{ \"message\": \"{message}\" }}", "application/json");

            }
            catch (Exception e)
            {

                throw new Exception(e.Message + e.InnerException?.Message);
            }

        }


        //Teacher Area-------------------------------------
        [HttpGet]
        [Route ( "GetTeacherQuizeCardLive" )]
        public async Task<IActionResult> GetTeacherQuizeCardLive ( string Uid )
        {
            try
            {
                var res       = await quizService.GetAll();
                var classes   = await _classService.GetAll();
                var session   = await _sessionService.GetAll();
                var subject   = await _subjectService.GetAll();
                var themes    = await _schoolThemesService.GetAll();
                var chapters  = await _chapterService.GetAll();
                var permssion = await _permissionService.GetAll();
                var subjects = classes.
                     Join
                     (
                        session,
                               (c) =>      new { id = c.SesssionId },
                               (s) =>      new { id = s.Id },
                               (c, s) =>   new { c, s }
                     )
                     .Join
                     (
                        subject,
                               (c) =>      new { id = c.c.Id },
                               (su) =>     new { id = su.ClassId },
                               (c, su) =>  new { c.c, c.s, su }
                     )                     
                     .Join                 
                     (                     
                       permssion,          
                              (s)=>        new {Id=s.su.Id},
                              (p)=>        new {Id=p.SubjectId.Value},
                              (s,p)=>      new {s.s,s.c,s.su,p }
                     )                     
                     .Join                 
                     (                     
                       themes,             
                            (su) =>        new { id = su.su.Id },
                            (t) =>         new { id = t.SubjectId },
                            (su, t) =>     new { su.c, su.su, su.s,su.p, t }
                     )                     
                     .Join                 
                     (                     
                      chapters,
                            (th) =>        new { id = th.t.Id },
                            (chap) =>      new { id = chap.ThemeId },
                            (th, chap) =>  new { th.c, th.su, th.s, th.t,th.p, chap }
                     )                     
                     .Join                 
                     (                     
                         res,              
                           (chap)      =>  new {id=chap.chap.Id},
                           (res)       =>  new {id=res.chapterId},
                           (chap,cous) =>  new {chap.p,cous}
                      )
                     .Where
                     (
                           x=>
                           x.cous.status  == "Live" &&
                           x.p.TeacherId  == Uid
                     )
                     .Select
                     ( 
                       post=> new QuizDto
                      {
                          Id          = post.cous.Id,
                          Title       = post.cous.Title,
                          Status      = post.cous.status,
                          chapterId   = post.cous.chapterId,
                          Questions   = JsonConvert.DeserializeObject<List<QuestionDto>>(post.cous.questions)
                      }
                     )
                     .ToList();
                return Ok ( subjects );
            }
            catch ( Exception e )
            {

                throw new Exception ( e.Message + e.InnerException?.Message );
            }

        }

        [HttpGet]
        [Route ( "GetTeacherQuizeCardDraft" )]
        public async Task<IActionResult> GetTeacherQuizeCardDraft ( string Uid )
        {
            try
            {
                var res       = await quizService.GetAll();
                var classes   = await _classService.GetAll();
                var session   = await _sessionService.GetAll();
                var subject   = await _subjectService.GetAll();
                var themes    = await _schoolThemesService.GetAll();
                var chapters  = await _chapterService.GetAll();
                var permssion = await _permissionService.GetAll();
                var subjects = classes.
                     Join
                     (
                        session,
                               (c) =>      new { id = c.SesssionId },
                               (s) =>      new { id = s.Id },
                               (c, s) =>   new { c, s }
                     )
                     .Join
                     (
                        subject,
                               (c) =>      new { id = c.c.Id },
                               (su) =>     new { id = su.ClassId },
                               (c, su) =>  new { c.c, c.s, su }
                     )
                     .Join
                     (
                       permssion,
                              (s)=>        new {Id=s.su.Id},
                              (p)=>        new {Id=p.SubjectId.Value},
                              (s,p)=>      new {s.s,s.c,s.su,p }
                     )
                     .Join
                     (
                       themes,
                            (su) =>        new { id = su.su.Id },
                            (t) =>         new { id = t.SubjectId },
                            (su, t) =>     new { su.c, su.su, su.s,su.p, t }
                     )
                     .Join
                     (
                      chapters,
                            (th) =>        new { id = th.t.Id },
                            (chap) =>      new { id = chap.ThemeId },
                            (th, chap) =>  new { th.c, th.su, th.s, th.t,th.p, chap }
                     )
                     .Join
                     (
                         res,
                           (chap)      =>  new {id=chap.chap.Id},
                           (res)       =>  new {id=res.chapterId},
                           (chap,cous) =>  new {chap.p,cous}
                      )
                     .Where
                     (
                      x=>
                      x.cous.status=="Draft" &&
                      x.p.TeacherId==Uid
                     )
                     .Select
                     (
                       post=> new QuizDto
                       {
                           Id        = post.cous.Id,
                           Title     = post.cous.Title,
                           Status    = post.cous.status,
                           chapterId = post.cous.chapterId,
                           Questions = JsonConvert.DeserializeObject<List<QuestionDto>>(post.cous.questions)
                       }
                     )
                     .ToList();
                return Ok ( subjects );
            }
            catch ( Exception e )
            {

                throw new Exception ( e.Message + e.InnerException?.Message );
            }

        }


        [HttpGet]
        [Route ( "GetTeacherQuizOfChapter" )]
        public async Task<IActionResult> GetTeacherQuizOfChapter ( string Uid,int Id )
        {
            try
            {
                var res       = await quizService.GetAll();
                var classes   = await _classService.GetAll();
                var session   = await _sessionService.GetAll();
                var subject   = await _subjectService.GetAll();
                var themes    = await _schoolThemesService.GetAll();
                var chapters  = await _chapterService.GetAll();
                var permssion = await _permissionService.GetAll();
                var subjects  = classes.Join
                     (
                        session,
                               (c) =>      new { id = c.SesssionId },
                               (s) =>      new { id = s.Id },
                               (c, s) =>   new { c, s }
                     )
                     .Join
                     (
                        subject,
                               (c) =>      new { id = c.c.Id },
                               (su) =>     new { id = su.ClassId },
                               (c, su) =>  new { c.c, c.s, su }
                     )
                     .Join
                     (
                       permssion,
                              (s)=>        new {Id=s.su.Id},
                              (p)=>        new {Id=p.SubjectId.Value},
                              (s,p)=>      new {s.s,s.c,s.su,p }
                     )
                     .Join
                     (
                       themes,
                            (su) =>        new { id = su.su.Id },
                            (t) =>         new { id = t.SubjectId },
                            (su, t) =>     new { su.c, su.su, su.s,su.p, t }
                     )
                     .Join
                     (
                      chapters,
                            (th) =>        new { id = th.t.Id },
                            (chap) =>      new { id = chap.ThemeId },
                            (th, chap) =>  new { th.c, th.su, th.s, th.t,th.p, chap }
                     )
                     .Join
                     (
                         res,
                           (chap)      =>  new {id=chap.chap.Id},
                           (res)       =>  new {id=res.chapterId},
                           (chap,cous) =>  new {chap.chap,chap.p,cous}
                      )
                     .Where
                     (
                      x=>
                      x.cous.status == "Live" &&
                      x.chap.Id     == Id   &&
                      x.p.TeacherId == Uid
                     )
                     .Select
                     (
                       post=> new QuizDto
                       {
                           Id        = post.cous.Id,
                           Title     = post.cous.Title,
                           Status    = post.cous.status,
                           chapterId = post.cous.chapterId,
                           Questions = JsonConvert.DeserializeObject<List<QuestionDto>>(post.cous.questions)
                       }
                     )
                     .ToList();
                return Ok ( subjects );
            }
            catch ( Exception e )
            {

                throw new Exception ( e.Message + e.InnerException?.Message );
            }

        }



        //Admin Area-------------------------------
        //quiz cards get
        [HttpGet]
        public override async Task<IActionResult> GetAll()
        {
            try
            {
                IList<QuizPosts> res = (IList<QuizPosts>)await genericService.GetAll();
                List<QuizDto> quizzes = res.Select(post => new QuizDto
                {
                    Id        = post.Id,
                    Title     = post.Title,
                    Status    = post.status,
                    chapterId = post.chapterId,
                    Questions = JsonConvert.DeserializeObject<List<QuestionDto>>(post.questions)
                })
                .ToList();
                return Ok(quizzes);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message + e.InnerException?.Message);
            }

        }

        [HttpGet]
        [Route("GetQuizOfChapters")]
        public  async Task<IActionResult> GetQuizOfChapters(int id)
        {
            try
            {
                IList<QuizPosts> res  = (IList<QuizPosts>)await genericService.GetAll();
                List<QuizDto> quizzes = res.Select(post => new QuizDto
                {
                    Id = post.Id,
                    Title = post.Title,
                    Status = post.status,
                    chapterId = post.chapterId,
                    Questions = JsonConvert.DeserializeObject<List<QuestionDto>>(post.questions)
                })
                .ToList();
                var filtered=quizzes.Where(x=>x.chapterId== id).ToList();
                return Ok(filtered);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message + e.InnerException?.Message);
            }

        }

        [HttpGet]
        [Route("getDetailQuiz")]
        public  async Task<IActionResult> getDetailQuiz(int number)
        {
            try
            {
                QuizPosts res = await genericService.Get(number);
                if (res != null)
                {
                    QuizDto quizzes = new QuizDto()
                    {
                        Id=res.Id,
                        Title = res.Title,
                        Status = res.status,
                        chapterId = res.chapterId,
                        Questions = JsonConvert.DeserializeObject<List<QuestionDto>>(res.questions)
                    };
                    return Ok(quizzes);
                }

                return Ok(res);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message + e.InnerException?.Message);
            }

        }
    
    
    }
}
