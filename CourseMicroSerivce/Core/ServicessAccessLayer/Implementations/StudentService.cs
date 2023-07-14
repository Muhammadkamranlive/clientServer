using CourseMicroSerivce.Domain;
using Project.BusinessAccessLayer.Repositories.ModelRepositories;
using Project.BusinessAccessLayer.Repositories.Unit;
using Project.ServicessAccessLayer.Contracts;
namespace Project.ServicessAccessLayer.Implementations
{
    public class StudentService:GenericService<Students>,IStudentService
    {
    
        public StudentService(IUnitOfWork unitOfWork,IStudentRepository studentRepository):base(unitOfWork,studentRepository)
        {
          
            
        }
    }
}
