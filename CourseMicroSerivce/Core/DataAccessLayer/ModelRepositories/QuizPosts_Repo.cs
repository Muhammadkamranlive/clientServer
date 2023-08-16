using CourseMicroSerivce.Core.BusinessAccessLayer.Repositories.ModelRepositories;
using CourseMicroSerivce.Core.DataAccessLayer.GenericRepository;
using CourseMicroSerivce.Domain.TeacherPortal;
using Project.DataAccess;

namespace CourseMicroSerivce.Core.DataAccessLayer.ModelRepositories
{
    public class QuizPosts_Repo:Repo<QuizPosts>, IQuizPosts_Repo
    {
        public QuizPosts_Repo(SchoolContext coursecontext) : base(coursecontext)
        {

        }
    }
}
