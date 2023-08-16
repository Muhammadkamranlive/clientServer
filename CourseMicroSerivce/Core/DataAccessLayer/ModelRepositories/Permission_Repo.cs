using CourseMicroSerivce.Core.BusinessAccessLayer.Repositories.ModelRepositories;
using CourseMicroSerivce.Core.DataAccessLayer.GenericRepository;
using CourseMicroSerivce.Domain.TeacherPortal;
using Project.DataAccess;

namespace CourseMicroSerivce.Core.DataAccessLayer.ModelRepositories
{
    public class Permission_Repo:Repo<PermissionManagment>, IPermission_Repo
    {
        public Permission_Repo(SchoolContext coursecontext) : base(coursecontext)
        {
            
        }
    }
}
