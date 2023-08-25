using CourseMicroSerivce.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace CourseMicroSerivce.Domain.AuthenticationModels
{
    public class Student:ApplicationUser
    {
        public DateTime endDate { get; set; }
        public DateTime startDate { get; set; }
        public string  paymentToken { get; set; }
        public string speakingLanguage { get; set; }
    }
}
