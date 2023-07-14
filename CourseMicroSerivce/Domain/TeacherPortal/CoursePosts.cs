namespace CourseMicroSerivce.Domain.TeacherPortal
{
    public class CoursePosts
    {
        public int    Id                    { get; set; }
        public string Title                 { get; set; }
        public string Status                { get; set; }
        public string Description           { get; set; }
        public int    SchoolCourseId        { get; set; }
        public SchoolCourses? SchoolCourses { get; set; }
       
        

    }
}
