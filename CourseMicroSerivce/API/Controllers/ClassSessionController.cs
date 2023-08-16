using AutoMapper;
using CourseMicroSerivce.Core.ServicessAccessLayer.Contracts.DomainContracts;
using CourseMicroSerivce.Domain;
using CourseMicroSerivce.Domain.TeacherPortal;
using CourseMicroSerivce.Models.AutoMapperDTOS;
using CourseMicroSerivce.Models.TeacherPortal;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Controllers;
using Project.ServicessAccessLayer.Contracts.AuthContracts;

namespace CourseMicroSerivce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = ("Administrator"))]
    public class ClassSessionController : ParentController<ClassesSessions, ClassSessionModel>
    {
        private readonly IClassesSessions_Service _sessionService;
        private readonly ISchoolClasses_Service _schoolClassesService;
        private readonly ISchoolSubjects_Service _schoolSubjectsService;
        private readonly ISchoolThemes_Service _schoolThemesService;
        private readonly IAuthManager _authManager;
        private readonly IMapper _mapper;
        public ClassSessionController(IClassesSessions_Service Service,  IMapper mapper, IClassesSessions_Service sessionService, ISchoolClasses_Service schoolClassesService, ISchoolSubjects_Service schoolSubjectsService, ISchoolThemes_Service schoolThemesService,IAuthManager authManager) : base(Service, mapper)
        {
            _sessionService = sessionService;
            _schoolClassesService = schoolClassesService;
            _schoolSubjectsService = schoolSubjectsService;
            _schoolThemesService = schoolThemesService;
            _authManager = authManager;
            _mapper = mapper;
        }



        [HttpGet]
        [Route("Summary")]
        public async Task<IActionResult> GetSummary()
        {



            try
            {
                var sessions= await _sessionService.GetAll();
                var classCount= await _schoolClassesService.GetAll();
                var SubJectCount= await _schoolSubjectsService.GetAll();
                var themeCount= await _schoolThemesService.GetAll();
                var authors =await _authManager.GetCountuser();
                var summary = new SummaryModel
                {
                    sessions = sessions.Count(),
                    classesLive = classCount.Where(x => x.status == "Live").Count(),
                    classNotLive = classCount.Where(x => x.status == "Draft").Count(),
                    SubjectCount = SubJectCount.Count(),
                    LiveSubjects = SubJectCount.Where(x => x.Status == "Live").Count(),
                    themeCount = themeCount.Count(),
                    authors = authors,
                };
                return Ok(summary);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message + e.InnerException?.Message);
            }

        }


        [HttpGet]
        [Route("GetcontentSummary")]
        public async Task<IActionResult> GetcontentSummary()
        {



            try
            {
                IList<ClassesSessions> sessions = (IList<ClassesSessions>)await _sessionService.GetAll();
                IList<SchoolClasses> classCount = (IList<SchoolClasses>)await _schoolClassesService.GetAll();
                IList<SchoolSubjects> SubJectCount = (IList<SchoolSubjects>)await _schoolSubjectsService.GetAll();
                var themeCount = await _schoolThemesService.GetAll();
                var authors = await _authManager.GetList();
                var summary = new SummaryModel
                {
                    sessions     = sessions,
                    classesLive  = classCount,
                    classNotLive = classCount,
                    SubjectCount = SubJectCount,
                    LiveSubjects = SubJectCount.Where(x => x.Status == "Live").ToList(),
                    themeCount   = themeCount.ToList(),
                    authors      = authors,
                };
                return Ok(summary);
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
                var result = await _sessionService.GetAll();
                var clientResult = _mapper.Map<IList<ClassSessionModel>>(result.Where(x=>x.status=="Live").ToList());
                return Ok(clientResult);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message + e.InnerException?.Message);
            }

        }

        [HttpGet]
        [Route("GetAlldRAFT")]
        public  async Task<IActionResult> GetAlldRAFT()
        {



            try
            {
                var result = await _sessionService.GetAll();
                var clientResult = _mapper.Map<IList<ClassSessionModel>>(result.Where(x => x.status == "Draft").ToList());
                return Ok(clientResult);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message + e.InnerException?.Message);
            }

        }



    }
}
