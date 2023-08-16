using System.ComponentModel.DataAnnotations;

namespace CourseMicroSerivce.Models.AutoMapperDTOS
{
    public class TeacherDto
    {
        [Required(ErrorMessage ="First Name is Required ")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is Required ")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email Name is Required ")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password  is Required ")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Expire Date is Required ")]
        public DateTime ExpirationDate { get; set; }
        
        
    }
}
