using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.BusinessAccessLayer.Repositories.ModelRepositories;
using CourseMicroSerivce.Core.DataAccessLayer.GenericRepository;
using CourseMicroSerivce.Domain;

namespace Project.DataAccess.InterfacesImplementations
{
    public class CourseRepository:GenericRepository<Courses>,ICourseRepository
    {
        public CourseRepository(Coursecontext courseContent):base(courseContent)
        {

        }
    }
}
