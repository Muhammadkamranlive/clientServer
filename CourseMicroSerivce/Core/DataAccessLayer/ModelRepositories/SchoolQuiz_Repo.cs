using CourseMicroSerivce.Core.BusinessAccessLayer.Repositories.ModelRepositories;
using CourseMicroSerivce.Core.DataAccessLayer.GenericRepository;
using CourseMicroSerivce.Domain.TeacherPortal;
using Project.DataAccess;

namespace CourseMicroSerivce.Core.DataAccessLayer.ModelRepositories
{
    public class SchoolQuiz_Repo:Repo<SchoolQuiz>, ISchoolQuiz_Repo
    {
        public SchoolQuiz_Repo(SchoolContext coursecontext) : base(coursecontext)
        {

        }
    }
}
