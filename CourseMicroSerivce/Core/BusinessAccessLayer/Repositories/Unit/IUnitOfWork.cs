using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseMicroSerivce.Core.BusinessAccessLayer.Repositories.ModelRepositories;

namespace Project.BusinessAccessLayer.Repositories.Unit
{
   public interface IUnitOfWork:IDisposable
    {



        //Teacher Portal
        public IPermission_Repo Permission_Repo { get;  }
        public IVideoPost_Repo Video_Repo { get; }
        public IClassesSessions_Repo ClassesSessionRepo      { get; }
        public ICoursePosts_Repo CoursePostsRepo             { get; }
        public IQuizPosts_Repo QuizPostsRepo                 { get; }
        public ISchoolChapters_Repo SchoolChaptersRepo       { get; }
        public ISchoolClasses_Repo SchoolClassesRepo         { get; }
        public ISchoolCourses_Repo SchoolCoursesRepo         { get; }
        public ISchoolQuiz_Repo SchoolQuizRepo               { get; }
        public ISchoolSubjects_Repo SchoolSubjectsRepo       { get; }
        public ISchoolThemes_Repo SchoolThemesRepo           { get; }
        Task<int> Save();
    }
}
