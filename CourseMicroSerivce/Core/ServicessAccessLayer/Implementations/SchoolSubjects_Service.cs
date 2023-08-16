using CourseMicroSerivce.Core.BusinessAccessLayer.Repositories.ModelRepositories;
using CourseMicroSerivce.Core.ServicessAccessLayer.Contracts.DomainContracts;
using CourseMicroSerivce.Domain.TeacherPortal;

using Project.BusinessAccessLayer.Repositories.Unit;
using Project.ServicessAccessLayer.Implementations;

namespace CourseMicroSerivce.Core.ServicessAccessLayer.Implementations
{
    public class SchoolSubjects_Service:Base_Service<SchoolSubjects>, ISchoolSubjects_Service
    {
        public SchoolSubjects_Service(IUnitOfWork unitOfWork, ISchoolSubjects_Repo schoolSubjects_Repo) : base(unitOfWork, schoolSubjects_Repo)
        {

        }
    }
}
