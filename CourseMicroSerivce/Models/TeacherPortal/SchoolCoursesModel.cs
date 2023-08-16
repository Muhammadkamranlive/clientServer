using System.ComponentModel.DataAnnotations;

namespace CourseMicroSerivce.Models.TeacherPortal
{
    public class SchoolCoursesModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name / Title  is Required")]
        public string Name { get; set; }

        public string? image { get; set; }
        [Required(ErrorMessage = "status  is Required")]
        public string status { get; set; }
        [Required(ErrorMessage = "Content type  is Required")]
        public string CourseType { get; set; }
        [Required(ErrorMessage = "Chapter   is Required")]
        public int ChapterId { get; set; }

    }
}
