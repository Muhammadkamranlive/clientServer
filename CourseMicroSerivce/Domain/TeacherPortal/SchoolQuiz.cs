using System.ComponentModel.DataAnnotations;

namespace CourseMicroSerivce.Domain.TeacherPortal
{
    public class SchoolQuiz
    {
        public SchoolQuiz()
        {
                QuizPosts= new HashSet<QuizPosts>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Name /Title  is Required")]
        public string Name { get; set; }
        
        public string? image { get; set; }
        [Required(ErrorMessage = "status  is Required")]
        public string status { get; set; }
        [Required(ErrorMessage = "Content   Type  is Required")]
        public string ContentType { get; set; }
        [Required(ErrorMessage = "Chapter  is Required")]
        public int ChapterId { get; set; }
        public ICollection<QuizPosts> QuizPosts { get; set; }
    }
}
