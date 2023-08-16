using System.ComponentModel.DataAnnotations;

namespace CourseMicroSerivce.Models.TeacherPortal
{
    public class SchoolChaptersModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name /Title  is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "status   is Required")]
        public string status { get; set; }
        [Required(ErrorMessage = "Subject Theme  is Required")]
        public int ThemeId { get; set; }


    }
}
