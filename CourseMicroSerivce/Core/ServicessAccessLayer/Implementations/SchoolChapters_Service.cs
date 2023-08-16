using CourseMicroSerivce.Core.BusinessAccessLayer.Repositories.ModelRepositories;
using CourseMicroSerivce.Core.ServicessAccessLayer.Contracts.DomainContracts;
using CourseMicroSerivce.Domain.TeacherPortal;

using Project.BusinessAccessLayer.Repositories.Unit;
using Project.ServicessAccessLayer.Implementations;

namespace CourseMicroSerivce.Core.ServicessAccessLayer.Implementations
{
    public class SchoolChapters_Service:Base_Service<SchoolChapters>, ISchoolChapters_Service
    {
        public SchoolChapters_Service(IUnitOfWork unitOfWork, ISchoolChapters_Repo  schoolChapters_Repo) : base(unitOfWork, schoolChapters_Repo)
        {

        }
    }
}
