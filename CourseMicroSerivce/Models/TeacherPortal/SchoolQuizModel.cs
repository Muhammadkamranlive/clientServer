using System.ComponentModel.DataAnnotations;

namespace CourseMicroSerivce.Models.TeacherPortal
{
    public class SchoolQuizModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="User Must Required Please Login to Attempt it")]
        public string UserId { get; set; }
        public int CorrectAnswers { get; set; }
        public int WrongAnswers { get; set; }
        public int TotalQuestions { get; set; }

    }
}
