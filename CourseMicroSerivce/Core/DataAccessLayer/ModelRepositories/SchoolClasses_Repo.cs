using CourseMicroSerivce.Core.BusinessAccessLayer.Repositories.ModelRepositories;
using CourseMicroSerivce.Core.DataAccessLayer.GenericRepository;
using CourseMicroSerivce.Domain.TeacherPortal;
using Project.DataAccess;

namespace CourseMicroSerivce.Core.DataAccessLayer.ModelRepositories
{
    public class SchoolClasses_Repo:Repo<SchoolClasses>, ISchoolClasses_Repo
    {
        public SchoolClasses_Repo(SchoolContext coursecontext) : base(coursecontext)
        {

        }
    }
}
