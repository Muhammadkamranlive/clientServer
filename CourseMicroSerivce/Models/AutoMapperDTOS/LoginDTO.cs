using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseMicroSerivce.Models.AutoMapperDTOS
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Your password is limited {2} to {1} characters",
            MinimumLength = 6)]
        public string Password { get; set; }

    }
}
