using System.ComponentModel.DataAnnotations;

namespace CourseMicroSerivce.Domain.TeacherPortal
{
    public class QuizPosts
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is Required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "status  is Required")]
        public string status { get; set; }

        [Required(ErrorMessage = "Quiz Card is Required")]
        public int chapterId { get; set; }
        public string questions  { get; set; }
    }
}
