using CourseMicroSerivce.Domain;
using Project.BusinessAccessLayer.Repositories.ModelRepositories;
using Project.BusinessAccessLayer.Repositories.Unit;
using Project.ServicessAccessLayer.Contracts.DomainContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.ServicessAccessLayer.Implementations
{
    public class CourseContentService:GenericService<CourseContent>,ICourseContentService
    {
        public CourseContentService(IUnitOfWork unitOfWork,ICourseContentRepository courseContentRepository ):base(unitOfWork,courseContentRepository)
        {

        }
    }
}
