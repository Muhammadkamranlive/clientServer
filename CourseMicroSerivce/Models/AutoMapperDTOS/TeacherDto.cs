using CourseMicroSerivce.Domain.AuthenticationModels;
using System.ComponentModel.DataAnnotations;

namespace CourseMicroSerivce.Models.AutoMapperDTOS
{
    public class TeacherDto
    {
        [Required(ErrorMessage = "Username is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        public string Image { get; set; }

        [Required(ErrorMessage = "Address Line 1 is required.")]
        public string AddressLine1 { get; set; }

        [Required(ErrorMessage = "ZIP Code is required.")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Expiration Date is required.")]
        public DateTime ExpirationDate { get; set; }

        [Required(ErrorMessage = "Starting Date is required.")]
        public DateTime StartingDate { get; set; }

        [Required(ErrorMessage = "Language is required.")]
        public string Language { get; set; }

        [Required(ErrorMessage = "class is required.")]
        public int?   ClassId { get; set; }

        [Required(ErrorMessage = "session is required.")]
        public int?  SessionId { get; set; }

    }
}
