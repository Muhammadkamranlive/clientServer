using CourseMicroSerivce.Domain;
using Project.BusinessAccessLayer.Repositories.ModelRepositories;
using Project.BusinessAccessLayer.Repositories.Unit;
using Project.DataAccess.InterfacesImplementations;
using Project.ServicessAccessLayer.Contracts.DomainContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.ServicessAccessLayer.Implementations
{
    public class TagsService:GenericService<Tags>,ITagsService
    {
        public TagsService(IUnitOfWork unitOfWork,ITagRespository tagsRepository ):base(unitOfWork,tagsRepository)
        {

        }
    }
}
