using Autofac;
using CourseMicroSerivce.Core.BusinessAccessLayer.Repositories.ModelRepositories;
using CourseMicroSerivce.Core.DataAccessLayer.GenericRepository;
using CourseMicroSerivce.Core.DataAccessLayer.ModelRepositories;
using CourseMicroSerivce.Core.DataAccessLayer.UnitOfWork;
using CourseMicroSerivce.Core.ServicessAccessLayer.Contracts.DomainContracts;
using CourseMicroSerivce.Core.ServicessAccessLayer.Implementations;
using Project.BusinessAccessLayer.Repositories;
using Project.BusinessAccessLayer.Repositories.Unit;
using Project.ServicessAccessLayer.Contracts;
using Project.ServicessAccessLayer.Implementations;

namespace CourseMicroSerivce.DependencyInjectContainer
{
    public class DependencyInjectionContainer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(Repo<>)).As(typeof(IRepo<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Base_Service<>)).As(typeof(IBase_Service<>)).InstancePerLifetimeScope();
            


           

           


        }
    }
}
