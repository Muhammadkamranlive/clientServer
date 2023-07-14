using CourseMicroSerivce.Domain;
using Project.BusinessAccessLayer.Repositories.Unit;
using Project.DataAccess.InterfacesImplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.ServicessAccessLayer.Implementations
{
    public class PersonService:GenericService<Person>
    {
        public PersonService(IUnitOfWork unitOfWork ,PersonRepository personRepository):base(unitOfWork,personRepository)
        {

        }
    }
}
