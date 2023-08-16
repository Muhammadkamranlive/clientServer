using CourseMicroSerivce.Core.BusinessAccessLayer.Repositories.ModelRepositories;
using CourseMicroSerivce.Core.DataAccessLayer.GenericRepository;
using CourseMicroSerivce.Domain.TeacherPortal;
using Project.DataAccess;

namespace CourseMicroSerivce.Core.DataAccessLayer.ModelRepositories
{
    public class SchoolThemes_Repo:Repo<SchoolThemes>, ISchoolThemes_Repo
    {
        public SchoolThemes_Repo(SchoolContext coursecontext) : base(coursecontext)
        {

        }
    }
}
