using System.ComponentModel.DataAnnotations;

namespace CourseMicroSerivce.Models.TeacherPortal
{
    public class VideoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title  is Required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "status  is Required")]
        public string status { get; set; }
        [Required(ErrorMessage = "Video  is Required")]
        public string video { get; set; }
        [Required(ErrorMessage = "Course    is Required")]
        public int SchoolCourseId { get; set; }
    }
}
