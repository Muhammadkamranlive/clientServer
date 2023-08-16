using CourseMicroSerivce.Core.BusinessAccessLayer.Repositories.ModelRepositories;
using CourseMicroSerivce.Core.ServicessAccessLayer.Contracts.DomainContracts;
using CourseMicroSerivce.Domain.TeacherPortal;

using Project.BusinessAccessLayer.Repositories.Unit;
using Project.ServicessAccessLayer.Implementations;

namespace CourseMicroSerivce.Core.ServicessAccessLayer.Implementations
{
    public class SchoolThemes_Service:Base_Service<SchoolThemes>, ISchoolThemes_Service
    {
        public SchoolThemes_Service(IUnitOfWork unitOfWork, ISchoolThemes_Repo schoolThemes_Repo) : base(unitOfWork, schoolThemes_Repo)
        {

        }
    }
}
