using System.ComponentModel.DataAnnotations;

namespace CourseMicroSerivce.Domain.TeacherPortal
{
    public class SchoolChapters
    {
        public SchoolChapters()
        {
            SchoolQuizzes=new HashSet<SchoolQuiz>();
            SchoolCourses=new HashSet<SchoolCourses>();
        }
        public int Id                                    { get; set; }
        [Required(ErrorMessage = "Name /Title  is Required")]
        public string Name                               { get; set; }
         public string? image { get; set; }
        [Required(ErrorMessage = "status   is Required")]
        public string status                             { get; set; }
        [Required(ErrorMessage = "Subject Theme  is Required")]
        public int ThemeId                               { get; set; }
        public SchoolThemes? SubjectThemes               { get; set; }
        public ICollection<SchoolQuiz>? SchoolQuizzes    { get; set; }
        public ICollection<SchoolCourses>? SchoolCourses { get; set; }

    }
}
