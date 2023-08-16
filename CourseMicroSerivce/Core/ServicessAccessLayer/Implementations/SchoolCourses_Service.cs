using CourseMicroSerivce.Core.BusinessAccessLayer.Repositories.ModelRepositories;
using CourseMicroSerivce.Core.ServicessAccessLayer.Contracts.DomainContracts;
using CourseMicroSerivce.Domain.TeacherPortal;
using Project.BusinessAccessLayer.Repositories.Unit;
using Project.ServicessAccessLayer.Implementations;

namespace CourseMicroSerivce.Core.ServicessAccessLayer.Implementations
{
    public class SchoolCourses_Service:Base_Service<SchoolCourses>, ISchoolCourses_Service
    {
        public SchoolCourses_Service(IUnitOfWork unitOfWork, ISchoolCourses_Repo schoolCourses_Repo) : base(unitOfWork, schoolCourses_Repo)
        {

        }
    }
}
