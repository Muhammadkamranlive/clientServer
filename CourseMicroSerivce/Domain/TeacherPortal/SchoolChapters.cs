namespace CourseMicroSerivce.Domain.TeacherPortal
{
    public class SchoolChapters
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string classStatus { get; set; }
        public int ThemeId { get; set; }
        public SchoolThemes? SubjectThemes { get; set; }
        public ICollection<SchoolQuiz>? SchoolQuizzes { get; set; }
        public ICollection<SchoolCourses>? SchoolCourses { get; set; }

    }
}
