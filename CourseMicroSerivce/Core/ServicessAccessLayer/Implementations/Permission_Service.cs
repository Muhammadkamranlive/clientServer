using CourseMicroSerivce.Core.BusinessAccessLayer.Repositories.ModelRepositories;
using CourseMicroSerivce.Core.ServicessAccessLayer.Contracts.DomainContracts;
using CourseMicroSerivce.Domain.TeacherPortal;
using Project.BusinessAccessLayer.Repositories.Unit;
using Project.ServicessAccessLayer.Implementations;

namespace CourseMicroSerivce.Core.ServicessAccessLayer.Implementations
{
    public class Permission_Service:Base_Service<PermissionManagment>,IPermission_Service
    {
        public Permission_Service(IUnitOfWork unitOfWork, IPermission_Repo permission_Repo) : base(unitOfWork, permission_Repo)
        {
            
        }
    }
}
