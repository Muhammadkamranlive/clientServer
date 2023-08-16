using CourseMicroSerivce.Core.BusinessAccessLayer.Repositories.ModelRepositories;
using CourseMicroSerivce.Core.ServicessAccessLayer.Contracts.DomainContracts;
using CourseMicroSerivce.Domain.TeacherPortal;
using Project.BusinessAccessLayer.Repositories.Unit;
using Project.ServicessAccessLayer.Implementations;

namespace CourseMicroSerivce.Core.ServicessAccessLayer.Implementations
{
    public class SchoolClasses_Service:Base_Service<SchoolClasses>, ISchoolClasses_Service
    {
        public SchoolClasses_Service(IUnitOfWork unitOfWork, ISchoolClasses_Repo schoolClasses_Repo) : base(unitOfWork, schoolClasses_Repo)
        {

        }
    }
}
