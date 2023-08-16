using CourseMicroSerivce.Core.BusinessAccessLayer.Repositories.ModelRepositories;
using CourseMicroSerivce.Core.ServicessAccessLayer.Contracts.DomainContracts;
using CourseMicroSerivce.Domain.TeacherPortal;
using Project.BusinessAccessLayer.Repositories.Unit;
using Project.ServicessAccessLayer.Implementations;

namespace CourseMicroSerivce.Core.ServicessAccessLayer.Implementations
{
    public class SchoolQuiz_Service:Base_Service<SchoolQuiz>, ISchoolQuiz_Service
    {
        public SchoolQuiz_Service(IUnitOfWork unitOfWork, ISchoolQuiz_Repo schoolQuiz_Repo) : base(unitOfWork, schoolQuiz_Repo)
        {

        }
    }
}
