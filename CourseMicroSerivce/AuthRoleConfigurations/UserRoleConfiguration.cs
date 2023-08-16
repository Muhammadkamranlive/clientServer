using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseMicroSerivce.AuthRoleConfigurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        private readonly string[] _roles = new string[]
        {
        "Administrator",
        "Teacher",
        "Student",
        "Parent",
        "developer"
            // Add more roles here if needed
        };

        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            foreach (var roleName in _roles)
            {
                
                var role = new IdentityRole
                {
                   
                    Name = roleName,
                    NormalizedName = roleName.ToUpper()
                };
                builder.HasData(role);
            }
        }
    }



}
