using CourseMicroSerivce.Domain.AuthenticationModels;

namespace CourseMicroSerivce.Domain.TeacherPortal
{
    public class SchoolSubjects
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int TeacherId { get; set; }
        public Teacher? Teachers { get; set; }
        public ICollection<SchoolThemes> SubjectThemes  { get; set; }
    }
}
