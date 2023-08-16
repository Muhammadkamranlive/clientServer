using System.ComponentModel.DataAnnotations;

namespace CourseMicroSerivce.Models.TeacherPortal
{
    public class SchoolThemesModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name /Title  is Required")]
        public string Name { get; set; }
        public string? image { get; set; }

        [Required(ErrorMessage = "status  is Required")]
        public string status { get; set; }

        [Required(ErrorMessage = "Subject  is Required")]
        public int SubjectId { get; set; }

    }
}
