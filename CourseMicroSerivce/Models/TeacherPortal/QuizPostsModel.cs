using CourseMicroSerivce.Domain.TeacherPortal;
using System.ComponentModel.DataAnnotations;

namespace CourseMicroSerivce.Models.TeacherPortal
{
    public class QuizPostsModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is Required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "status  is Required")]
        public string status { get; set; }

        [Required(ErrorMessage = "Quiz Card is Required")]
        public int chapterId { get; set; }
        public string questions { get; set; }

    }



    public class OptionDto
    {
        public string OptionText { get; set; }
    }

    public class QuestionDto
    {
        public string Text { get; set; }
        public List<OptionDto> Options { get; set; }
        public string CorrectAnswer { get; set; }
    }

    public class QuizDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public int chapterId { get; set; }
        public List<QuestionDto> Questions { get; set; }
    }

}
