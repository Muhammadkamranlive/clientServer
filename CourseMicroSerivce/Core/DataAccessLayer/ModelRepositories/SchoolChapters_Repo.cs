using CourseMicroSerivce.Core.BusinessAccessLayer.Repositories.ModelRepositories;
using CourseMicroSerivce.Core.DataAccessLayer.GenericRepository;
using CourseMicroSerivce.Domain.TeacherPortal;
using Project.DataAccess;

namespace CourseMicroSerivce.Core.DataAccessLayer.ModelRepositories
{
    public class SchoolChapters_Repo:Repo<SchoolChapters>, ISchoolChapters_Repo
    {
        public SchoolChapters_Repo(SchoolContext coursecontext) : base(coursecontext)
        {

        }
    }
}
