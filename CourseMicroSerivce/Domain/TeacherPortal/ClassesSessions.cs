using System.ComponentModel.DataAnnotations;

namespace CourseMicroSerivce.Domain.TeacherPortal
{
    public class ClassesSessions
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage ="status is Required")]
        public string status { get; set; }

        [Required(ErrorMessage = "start date is Required")]
        public string SessionStart { get; set; }
        [Required(ErrorMessage = "End Date  is Required")]
        public string SessionEnd { get; set; }

        [Required(ErrorMessage = "Language  is Required")]
        public string Language { get; set; }
        public ICollection<SchoolClasses>? SchoolClasses { get; set; }
    }
}
