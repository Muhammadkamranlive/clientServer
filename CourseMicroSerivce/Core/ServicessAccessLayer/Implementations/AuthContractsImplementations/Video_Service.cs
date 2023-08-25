using CourseMicroSerivce.Core.BusinessAccessLayer.Repositories.ModelRepositories;
using CourseMicroSerivce.Core.ServicessAccessLayer.Contracts.DomainContracts;
using CourseMicroSerivce.Domain.TeacherPortal;
using Project.BusinessAccessLayer.Repositories.Unit;
using Project.ServicessAccessLayer.Implementations;

namespace CourseMicroSerivce.Core.ServicessAccessLayer.Implementations.AuthContractsImplementations
{
    public class Video_Service : Base_Service<VideoContent>, IVideo_Service
    {
        public Video_Service(IUnitOfWork unitOfWork, IVideoPost_Repo videoPost_Repo) : base(unitOfWork, videoPost_Repo)
        {

        }
    }
}
