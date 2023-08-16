using AutoMapper;
using CourseMicroSerivce.Core.ServicessAccessLayer.Contracts.DomainContracts;
using CourseMicroSerivce.Domain.AuthenticationModels;
using CourseMicroSerivce.Domain.TeacherPortal;
using CourseMicroSerivce.Models.TeacherPortal;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Controllers;
using Project.ServicessAccessLayer.Contracts.AuthContracts;
using System.Data;

namespace CourseMicroSerivce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = ("Administrator"))]
    public class PermissionController : ParentController<PermissionManagment, PermissionModel>
    {
        private readonly IPermission_Service _permissionService;
        private readonly ISchoolClasses_Service _schoolClassesService;
        private readonly ISchoolSubjects_Service _schoolSubjectsService;
        private readonly IAuthManager _authManager;
        public PermissionController(IPermission_Service Service, IMapper mapper, ISchoolClasses_Service schoolClassesService, ISchoolSubjects_Service schoolSubjectsService,IAuthManager authManager) : base(Service, mapper)
        {
            _permissionService = Service;
            _schoolClassesService = schoolClassesService;
            _schoolSubjectsService = schoolSubjectsService;
            _authManager = authManager;

        }

        [HttpGet]
        public override async Task<IActionResult> GetAll()
        {

            try
            {
                IList<PermissionManagment> permissions = (IList<PermissionManagment>)await _permissionService.GetAll();
                IList<SchoolClasses> classes           = (IList<SchoolClasses>)await _schoolClassesService.GetAll();
                IList<SchoolSubjects> Subjects         = (IList<SchoolSubjects>)await _schoolSubjectsService.GetAll();
                IList<ApplicationUser> Teacher                 = (IList<ApplicationUser>)await _authManager.GetList();
                var res = permissions.
                    Join
                    (
                      Teacher,
                      (p) => new { Id = p.TeacherId },
                      (t) => new { Id = t.Id },
                      (p, t) => new { p, t }
                    )
                    .
                    Join
                    (
                     classes,
                     (p) => new { Id = p.p.ClassId },
                     (c) => new { Id = c.Id },
                     (p, c) => new { p.p, p.t, c }
                    )
                    .
                    GroupJoin
                    (
                      Subjects,
                      (p) => new { Id = p.p.SubjectId.Value },
                      (s) => new { Id = s.Id },
                      (p, s) => new { p.p, p.t, p.c, s }
                    )
                    .SelectMany
                    (
                      s => s.s.DefaultIfEmpty(),
                      (s,p)=> new
                      {
                          Id=s.p.Id,
                          status      = s.p.status,
                          ClassId     = s.p.ClassId,
                          SubjectId   = s.p.SubjectId.Value,
                          TeacherId   = s.p.TeacherId,
                          TeacherName = s.t.FirstName +" "+s.t.LastName,
                          Email       = s.t.Email,
                          ClassName   = s.c.Name,
                          subjectname = p!=null?p.Name:null,
                      }
                    )
                    .Where(x => x.status == "Live")
                    .ToList();


                return Ok(res);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message + e.InnerException?.Message);
            }

        }


        [HttpGet]
        [Route("GetAllDraftPermission")]
        public  async Task<IActionResult> GetAllDraftPermission()
        {

            try
            {
                IList<PermissionManagment> permissions = (IList<PermissionManagment>)await _permissionService.GetAll();
                IList<SchoolClasses> classes = (IList<SchoolClasses>)await _schoolClassesService.GetAll();
                IList<SchoolSubjects> Subjects = (IList<SchoolSubjects>)await _schoolSubjectsService.GetAll();
                IList<ApplicationUser> Teacher = (IList<ApplicationUser>)await _authManager.GetList();
                var res = permissions.
                    Join
                    (
                      Teacher,
                      (p) => new { Id = p.TeacherId },
                      (t) => new { Id = t.Id },
                      (p, t) => new { p, t }
                    )
                    .
                    Join
                    (
                     classes,
                     (p) => new { Id = p.p.ClassId },
                     (c) => new { Id = c.Id },
                     (p, c) => new { p.p, p.t, c }
                    )
                    .
                    GroupJoin
                    (
                      Subjects,
                      (p) => new { Id = p.p.SubjectId.Value },
                      (s) => new { Id = s.Id },
                      (p, s) => new { p.p, p.t, p.c, s }
                    )
                    .SelectMany
                    (
                      s => s.s.DefaultIfEmpty(),
                      (s, p) => new
                      {
                          Id = s.p.Id,
                          status = s.p.status,
                          ClassId = s.p.ClassId,
                          SubjectId = s.p.SubjectId.Value,
                          TeacherId = s.p.TeacherId,
                          TeacherName = s.t.FirstName + " " + s.t.LastName,
                          Email = s.t.Email,
                          ClassName = s.c.Name,
                          subjectname = p != null ? p.Name : null,
                      }
                    )
                    .Where(x=>x.status=="Draft")
                    .ToList();


                return Ok(res);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message + e.InnerException?.Message);
            }

        }


    }
}
