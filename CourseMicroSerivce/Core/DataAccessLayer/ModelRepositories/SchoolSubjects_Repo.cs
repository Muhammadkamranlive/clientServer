using CourseMicroSerivce.Core.BusinessAccessLayer.Repositories.ModelRepositories;
using CourseMicroSerivce.Core.DataAccessLayer.GenericRepository;
using CourseMicroSerivce.Domain.TeacherPortal;
using Project.DataAccess;

namespace CourseMicroSerivce.Core.DataAccessLayer.ModelRepositories
{
    public class SchoolSubjects_Repo:Repo<SchoolSubjects>, ISchoolSubjects_Repo
    {
        public SchoolSubjects_Repo(SchoolContext coursecontext) : base(coursecontext)
        {

        }
    }
}
