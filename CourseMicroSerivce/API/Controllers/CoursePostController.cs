using AutoMapper;
using CourseMicroSerivce.Core.ServicessAccessLayer.Contracts.DomainContracts;
using CourseMicroSerivce.Domain.TeacherPortal;
using CourseMicroSerivce.Models.TeacherPortal;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Controllers;

namespace CourseMicroSerivce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Teacher")]
    public class CoursePostController : ParentController<CoursePosts, CoursePostsModel>
    {
        public CoursePostController(ICoursePosts_Service Service, IMapper mapper) : base(Service, mapper)
        {

        }
    }
}
