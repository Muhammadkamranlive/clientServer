using Microsoft.AspNetCore.Identity;
namespace CourseMicroSerivce.Domain.AuthenticationModels
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName     { get; set; }
        public string LastName      { get; set; }
        public string Image         { get; set; }
        public int? ClassId         { get; set; }
        public int? SessionId       { get; set; }
        public string AddressLine1  { get; set; }
        public string ZipCode       { get; set; }
        public string City          { get; set; }
        public string Country       { get; set; }

    }
}
