using CourseMicroSerivce.Core.BusinessAccessLayer.Repositories.ModelRepositories;
using CourseMicroSerivce.Core.DataAccessLayer.GenericRepository;
using CourseMicroSerivce.Domain.TeacherPortal;
using Project.DataAccess;

namespace CourseMicroSerivce.Core.DataAccessLayer.ModelRepositories
{
    public class SchoolCourses_Repo:Repo<SchoolCourses>, ISchoolCourses_Repo
    {
        public SchoolCourses_Repo(SchoolContext coursecontext) : base(coursecontext)
        {

        }
    }
}
