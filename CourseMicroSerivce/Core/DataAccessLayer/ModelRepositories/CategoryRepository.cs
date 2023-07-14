using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseMicroSerivce.Core.DataAccessLayer.GenericRepository;
using CourseMicroSerivce.Domain;
using Project.BusinessAccessLayer.Repositories.ModelRepositories;
namespace Project.DataAccess.InterfacesImplementations
{
    public class CategoryRepository:GenericRepository<Category>,ICategoryRepository
    {
        public CategoryRepository(Coursecontext coursecontext):base(coursecontext)
        {

        }
    }
}
