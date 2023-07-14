using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.BusinessAccessLayer.Repositories.ModelRepositories;
using Project.BusinessAccessLayer.Repositories.Unit;
using Project.ServicessAccessLayer.Contracts;
using CourseMicroSerivce.Domain;

namespace Project.ServicessAccessLayer.Implementations
{
    public class TeacherService:GenericService<Teachers>,ITeacherService
    {
        public TeacherService(IUnitOfWork unitOfWork,ITeacherRepository teacherRepository):base(unitOfWork,teacherRepository)
        {

        }
    }
}
