namespace CourseMicroSerivce.Domain.TeacherPortal
{
    public class SchoolThemes
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; }
        public ICollection<SchoolChapters>? Chapters { get; set; }
        


    }
}
