using CourseMicroSerivce.Core.BusinessAccessLayer.Repositories.ModelRepositories;
using CourseMicroSerivce.Core.ServicessAccessLayer.Contracts.DomainContracts;
using CourseMicroSerivce.Domain.TeacherPortal;
using Project.BusinessAccessLayer.Repositories.Unit;
using Project.ServicessAccessLayer.Implementations;

namespace CourseMicroSerivce.Core.ServicessAccessLayer.Implementations
{
    public class CoursePosts_Service:Base_Service<CoursePosts>, ICoursePosts_Service
    {
        public CoursePosts_Service(IUnitOfWork unitOfWork, ICoursePosts_Repo coursePosts_Repo) : base(unitOfWork, coursePosts_Repo)
        {

        }
    }
}
