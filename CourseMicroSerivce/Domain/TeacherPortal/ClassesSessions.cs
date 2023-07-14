namespace CourseMicroSerivce.Domain.TeacherPortal
{
    public class ClassesSessions
    {
        public int Id { get; set; }
        public string SessionDate { get; set; }
        public string SessionStart { get; set; }
        public string SessionEnd { get; set; }
        public string classStatus { get; set; }
        public ICollection<SchoolClasses>? SchoolClasses { get; set; }
    }
}
