using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseMicroSerivce.AuthRoleConfigurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        //the IEntity type confuguration has the  method configure you need to implement your roles in this 
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new IdentityRole
                {
                    Name = "Teacher",
                    NormalizedName = "TEACHER"
                }
                ,
                new IdentityRole
                {
                    Name = "Student",
                    NormalizedName = "STUDENT"
                }
               );

        }
    }
}
