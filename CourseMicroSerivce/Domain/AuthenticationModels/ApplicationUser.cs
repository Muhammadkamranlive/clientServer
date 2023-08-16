using Microsoft.AspNetCore.Identity;
namespace CourseMicroSerivce.Domain.AuthenticationModels
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
