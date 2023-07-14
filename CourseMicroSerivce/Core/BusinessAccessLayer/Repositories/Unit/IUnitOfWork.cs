using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseMicroSerivce.Core.BusinessAccessLayer.Repositories.ModelRepositories;
using Project.BusinessAccessLayer.Repositories.ModelRepositories;
namespace Project.BusinessAccessLayer.Repositories.Unit
{
   public interface IUnitOfWork:IDisposable
    {
        //exposing  Repositories One by One here ...
        public ICourseContentRepository CourseContentRepository { get;}
        public ICourseRepository CourseRepository { get; }
        
        public ICategoryRepository CategoryRepository { get; }
        public ITagRespository TagRespository { get;}
        public ITeacherRepository TeacherRepository { get;}
        public IPersonRepository UserRepository { get;}
        public IStudentRepository StudentRepository { get;}


        //Teacher Portal
        public IClassesSessions_Repo ClassesSessions    { get; set; }
        public ICoursePosts_Repo CoursePosts            { get; set; }
        public IQuizPosts_Repo QuizPosts                { get; set; }
        public ISchoolChapters_Repo SchoolChapters      { get; set; }
        public ISchoolClasses_Repo SchoolClasses        { get; set; }
        public ISchoolCourses_Repo  SchoolCourses       { get; set; }
        public ISchoolQuiz_Repo  SchoolQuiz             { get; set; }
        public ISchoolSubjects_Repo SchoolSubjects      { get; set; }
        public ISchoolThemes_Repo SchoolThemes          { get; set; }
        Task<int> Save();
    }
}
