using System.ComponentModel.DataAnnotations;

namespace CourseMicroSerivce.Models.TeacherPortal
{
    public class ClassSessionModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "status is Required")]
        public string status { get; set; }

        [Required(ErrorMessage = "start date is Required")]
        public string SessionStart { get; set; }
        [Required(ErrorMessage = "End Date  is Required")]
        public string SessionEnd { get; set; }


    }
}
