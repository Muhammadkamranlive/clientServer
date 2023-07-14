namespace CourseMicroSerivce.Domain.TeacherPortal
{
    public class SchoolCourses
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; }
        public string CourseType { get; set; }
        public ICollection<CoursePosts>? CouresePost { get; set; }
    }
}
