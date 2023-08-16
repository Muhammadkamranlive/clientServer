using Project.BusinessAccessLayer.Repositories.Unit;

using Project.DataAccess;

using CourseMicroSerivce.Core.BusinessAccessLayer.Repositories.ModelRepositories;
using CourseMicroSerivce.Core.DataAccessLayer.ModelRepositories;

namespace CourseMicroSerivce.Core.DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly SchoolContext _courseContext;

        public UnitOfWork(SchoolContext courseContent)
        {
            _courseContext = courseContent;
           

            ClassesSessionRepo = new ClassesSessions_Repo(_courseContext);
            CoursePostsRepo    = new CoursePosts_Repo(_courseContext);
            QuizPostsRepo      = new QuizPosts_Repo(_courseContext);
            SchoolChaptersRepo = new SchoolChapters_Repo(_courseContext);
            SchoolClassesRepo  = new SchoolClasses_Repo(_courseContext);
            SchoolCoursesRepo  = new SchoolCourses_Repo(_courseContext);
            SchoolQuizRepo     = new SchoolQuiz_Repo(_courseContext);
            SchoolSubjectsRepo = new SchoolSubjects_Repo(_courseContext);
            SchoolThemesRepo   = new SchoolThemes_Repo(_courseContext);
            Permission_Repo    = new Permission_Repo(_courseContext);
        }
       

        public IClassesSessions_Repo ClassesSessionRepo { get; private set; }
        public ICoursePosts_Repo CoursePostsRepo { get; private set; }

        public IQuizPosts_Repo QuizPostsRepo { get; private set; }

        public ISchoolChapters_Repo SchoolChaptersRepo { get; private set; }

        public ISchoolClasses_Repo SchoolClassesRepo { get; private set; }

        public ISchoolCourses_Repo SchoolCoursesRepo { get; private set; }

        public ISchoolQuiz_Repo SchoolQuizRepo { get; private set; }

        public ISchoolSubjects_Repo SchoolSubjectsRepo { get; private set; }

        public ISchoolThemes_Repo SchoolThemesRepo { get; private set; }

        public IPermission_Repo Permission_Repo { get; private set; }

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
