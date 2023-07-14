using Autofac;
using Project.BusinessAccessLayer.Repositories;
using Project.BusinessAccessLayer.Repositories.Unit;
using Project.DataAccess.InterfacesImplementations;
using Project.ServicessAccessLayer.Contracts;
using Project.ServicessAccessLayer.Contracts.DomainContracts;
using Project.ServicessAccessLayer.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.BusinessAccessLayer.Repositories.ModelRepositories;
using CourseMicroSerivce.Middlewares;
using Microsoft.AspNetCore.Http;
using CourseMicroSerivce.Core.DataAccessLayer.UnitOfWork;
using CourseMicroSerivce.Core.DataAccessLayer.GenericRepository;

namespace CourseMicroSerivce.DependencyInjectContainer
{
    public class DependencyInjectionContainer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IRepo<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(GenericService<>)).As(typeof(IGenericService<>)).InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<TagsService>().As<ITagsService>().InstancePerLifetimeScope();
            builder.RegisterType<CourseContentService>().As<ICourseContentService>().InstancePerLifetimeScope();
            builder.RegisterType<CourseService>().As<ICourseService>().InstancePerLifetimeScope();
            builder.RegisterType<CategorService>().As<ICategoryService>().InstancePerLifetimeScope();
            builder.RegisterType<StudentService>().As<IStudentService>().InstancePerLifetimeScope();
            builder.RegisterType<TagsService>().As<ITagsService>().InstancePerLifetimeScope();
            builder.RegisterType<TeacherService>().As<ITeacherService>().InstancePerLifetimeScope();


            builder.RegisterType<TagsRepository>().As<ITagRespository>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CourseContentRepository>().As<ICourseContentRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CourseRepository>().As<ICourseRepository>().InstancePerLifetimeScope();
            builder.RegisterType<TeacherRepository>().As<ITeacherRepository>().InstancePerLifetimeScope();
            builder.RegisterType<PersonRepository>().As<IPersonRepository>().InstancePerLifetimeScope();
            builder.RegisterType<StudentRespository>().As<IStudentRepository>().InstancePerLifetimeScope();




        }
    }
}
