using CourseMicroSerivce.Domain;
using Project.BusinessAccessLayer.Repositories.ModelRepositories;
using Project.BusinessAccessLayer.Repositories.Unit;
using Project.ServicessAccessLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.ServicessAccessLayer.Implementations
{
    public class CourseService:GenericService<Courses>,ICourseService
    {
        public CourseService(IUnitOfWork unitOfWork,ICourseRepository courseRepository):base(unitOfWork,courseRepository)
        {

        }
    }
}
