using CourseMicroSerivce.Domain.AuthenticationModels;

namespace CourseMicroSerivce.Domain.TeacherPortal
{
    public class SchoolClasses
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Status { get; set; }
        public int  SesssionId { get; set; }
        public ICollection<Teacher>? Teachers { get; set; }
        public ClassesSessions? Sessions { get; set; }
        public ICollection<SchoolSubjects>? Subjects { get; set; }
    }
}
