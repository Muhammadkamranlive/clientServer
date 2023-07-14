using CourseMicroSerivce.Domain;
using Project.BusinessAccessLayer.Repositories.ModelRepositories;
using Project.BusinessAccessLayer.Repositories.Unit;
using Project.DataAccess.InterfacesImplementations;
using Project.ServicessAccessLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.ServicessAccessLayer.Implementations
{
    public class CategorService:GenericService<Category>,ICategoryService
    {
        public CategorService(IUnitOfWork unitOfWork,ICategoryRepository categoryRepository ):base(unitOfWork,categoryRepository)
        {

        }
    }
}
