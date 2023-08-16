using CourseMicroSerivce.Core.BusinessAccessLayer.Repositories.ModelRepositories;
using CourseMicroSerivce.Core.DataAccessLayer.GenericRepository;
using CourseMicroSerivce.Domain.TeacherPortal;
using Project.DataAccess;

namespace CourseMicroSerivce.Core.DataAccessLayer.ModelRepositories
{
    public class CoursePosts_Repo:Repo<CoursePosts>, ICoursePosts_Repo
    {
        public CoursePosts_Repo(SchoolContext courseContent) : base(courseContent)
        {

        }
    }
}
