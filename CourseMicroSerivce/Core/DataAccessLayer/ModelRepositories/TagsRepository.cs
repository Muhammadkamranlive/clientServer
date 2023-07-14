using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.BusinessAccessLayer.Repositories.ModelRepositories;
using CourseMicroSerivce.Core.DataAccessLayer.GenericRepository;
using CourseMicroSerivce.Domain;

namespace Project.DataAccess.InterfacesImplementations
{
    public class TagsRepository:GenericRepository<Tags>,ITagRespository
    {
        public TagsRepository(Coursecontext courseContent):base(courseContent)
        {

        }
    }
}
