using CourseMicroSerivce.Core.BusinessAccessLayer.Repositories.ModelRepositories;
using CourseMicroSerivce.Core.ServicessAccessLayer.Contracts.DomainContracts;
using CourseMicroSerivce.Domain.TeacherPortal;
using Project.BusinessAccessLayer.Repositories.Unit;
using Project.ServicessAccessLayer.Implementations;

namespace CourseMicroSerivce.Core.ServicessAccessLayer.Implementations
{
    public class ClassesSessions_Service:Base_Service<ClassesSessions>, IClassesSessions_Service
    {
        public ClassesSessions_Service(IUnitOfWork unitOfWork, IClassesSessions_Repo classesSessions_Repo) : base(unitOfWork, classesSessions_Repo)
        {

        }
    }
}
