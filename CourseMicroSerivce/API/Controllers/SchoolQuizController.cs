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
    public class SchoolQuizController : ParentController<SchoolQuiz, SchoolQuizModel>
    {
        public SchoolQuizController(ISchoolQuiz_Service Service, IMapper mapper) : base(Service, mapper)
        {

        }
    }
}
