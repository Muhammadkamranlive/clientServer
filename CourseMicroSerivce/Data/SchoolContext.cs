using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CourseMicroSerivce.AuthRoleConfigurations;
using CourseMicroSerivce.Domain.AuthenticationModels;
using CourseMicroSerivce.Domain;
using CourseMicroSerivce.Domain.TeacherPortal;
using Microsoft.AspNetCore.Identity;

namespace Project.DataAccess
{
    public class SchoolContext: IdentityDbContext<ApplicationUser>
    {
           
        public SchoolContext(DbContextOptions<SchoolContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }


        public virtual DbSet<SchoolChapters> SchoolChapters { get; set; }
        public virtual DbSet<ClassesSessions> ClassesSessions { get; set; }
        public virtual DbSet<CoursePosts> CoursePosts { get; set; }
        public virtual DbSet<QuizPosts> QuizPosts { get; set; }
        public virtual DbSet<SchoolClasses> SchoolClasses { get; set; }
        public virtual DbSet<SchoolCourses> SchoolCourses { get; set; }
        public virtual DbSet<SchoolQuiz> SchoolQuizzes { get; set; }
        public virtual DbSet<SchoolSubjects> SchoolSubjects { get; set; }
        public virtual DbSet<SchoolThemes> SchoolThemes { get; set; }
        public virtual DbSet<VideoContent> VideoContents { get; set; }
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<Student> StudentsUsers { get; set; }
        public virtual DbSet<Teacher> TeachersUsers { get; set; }
        public virtual DbSet<PermissionManagment> PermissionManagments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            //// Explicitly set the primary key for AspNetRoles
            //modelBuilder.Entity<IdentityRole>(entity =>
            //{
            //    entity.Property(e => e.Id).ValueGeneratedNever();
            //});
        }

    }
}
