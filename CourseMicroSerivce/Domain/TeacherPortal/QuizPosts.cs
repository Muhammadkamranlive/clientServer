namespace CourseMicroSerivce.Domain.TeacherPortal
{
    public class QuizPosts
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int SchooleQuizId { get; set; }
        public SchoolQuiz? SchoolQuiz { get; set; }
    }
}
