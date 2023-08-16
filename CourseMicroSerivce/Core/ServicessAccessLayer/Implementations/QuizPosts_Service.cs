using CourseMicroSerivce.Core.BusinessAccessLayer.Repositories.ModelRepositories;
using CourseMicroSerivce.Core.ServicessAccessLayer.Contracts.DomainContracts;
using CourseMicroSerivce.Domain.TeacherPortal;
using Project.BusinessAccessLayer.Repositories.Unit;
using Project.ServicessAccessLayer.Implementations;

namespace CourseMicroSerivce.Core.ServicessAccessLayer.Implementations
{
    public class QuizPosts_Service:Base_Service<QuizPosts>, IQuizPosts_Service
    {
        public QuizPosts_Service(IUnitOfWork unitOfWork, IQuizPosts_Repo quizPosts_Repo) : base(unitOfWork, quizPosts_Repo)
        {

        }
    }
}
