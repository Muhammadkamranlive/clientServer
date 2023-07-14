using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CourseMicroSerivce.AuthRoleConfigurations;
using CourseMicroSerivce.Domain.AuthenticationModels;
using CourseMicroSerivce.Domain;

namespace Project.DataAccess
{
    public class Coursecontext: IdentityDbContext<ApplicationUser>
    {
        // this cofiguration is only valid  for  the  .net 5.0.0 core  and .net 6 have very simplied version of identity db
        public Coursecontext()
        {
                
        }     
        public Coursecontext(DbContextOptions<Coursecontext> dbContextOptions)
            : base(dbContextOptions)
        {

        }


        public virtual DbSet<Teachers> Teachers { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Students> Students { get; set; }
       
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<CourseContent> CourseContents { get; set; }

        // this  will  help   to remove  Error id go.microsoft.com/fwlink/?linkid=851728
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                object p = optionsBuilder.UseSqlServer("Server=ATLRW-KAMREMUH1\\SQL2K19DEV;Database=CorseDb;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            
        }

    }
}
