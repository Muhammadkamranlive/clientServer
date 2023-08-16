using CourseMicroSerivce.Core.BusinessAccessLayer.Repositories.ModelRepositories;
using CourseMicroSerivce.Core.DataAccessLayer.GenericRepository;
using CourseMicroSerivce.Domain.TeacherPortal;
using Project.DataAccess;

namespace CourseMicroSerivce.Core.DataAccessLayer.ModelRepositories
{
    public class ClassesSessions_Repo : Repo<ClassesSessions>, IClassesSessions_Repo
    {
        public ClassesSessions_Repo(SchoolContext coursecontext) : base(coursecontext)
        {

        }
    }
}
