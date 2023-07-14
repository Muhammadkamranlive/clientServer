using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseMicroSerivce.Models;
using Project.BusinessAccessLayer.Repositories.Unit;
using Project.BusinessAccessLayer.Repositories.ModelRepositories;
using Project.DataAccess;
using Project.DataAccess.InterfacesImplementations;

namespace CourseMicroSerivce.Core.DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly Coursecontext _courseContext;

        public UnitOfWork(Coursecontext courseContent)
        {
            _courseContext = courseContent;
            CourseContentRepository = new CourseContentRepository(_courseContext);
            CourseRepository = new CourseRepository(_courseContext);
            CategoryRepository = new CategoryRepository(_courseContext);
            TagRespository = new TagsRepository(_courseContext);
            TeacherRepository = new TeacherRepository(_courseContext);
            UserRepository = new PersonRepository(_courseContext);
            StudentRepository = new StudentRespository(_courseContext);
        }
        public ICourseContentRepository CourseContentRepository { get; private set; }

        public ICourseRepository CourseRepository { get; private set; }



        public ICategoryRepository CategoryRepository { get; private set; }

        public ITagRespository TagRespository { get; private set; }

        public ITeacherRepository TeacherRepository { get; private set; }

        public IPersonRepository UserRepository { get; private set; }

        public IStudentRepository StudentRepository { get; private set; }

        public async void Dispose()
        {
            GC.SuppressFinalize(this);
            await _courseContext.DisposeAsync();
        }

        public async Task<int> Save()
        {
            return await _courseContext.SaveChangesAsync();
        }
    }
}
