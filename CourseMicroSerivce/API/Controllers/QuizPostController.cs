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
        public QuizPostController(IQuizPosts_Service Service, IMapper mapper) : base(Service, mapper)
        {

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
                await genericService.InsertAsync(clientData);
                await genericService.CompleteAync();
                var message = "Data Inserted Successfully for " ;
                return Content($"{{ \"message\": \"{message}\" }}", "application/json");

            }
            catch (Exception e)
            {

                throw new Exception(e.Message + e.InnerException?.Message);
            }

        }



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
                IList<QuizPosts> res = (IList<QuizPosts>)await genericService.GetAll();
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
