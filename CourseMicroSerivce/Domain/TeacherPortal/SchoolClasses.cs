using CourseMicroSerivce.Domain.AuthenticationModels;
using System.ComponentModel.DataAnnotations;

namespace CourseMicroSerivce.Domain.TeacherPortal
{
    public class SchoolClasses
    {
        public SchoolClasses()
        {
           
            Subjects = new HashSet<SchoolSubjects>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Name / Title  is Required")]
        public string Name { get; set; }
        public string? image { get; set; }
        [Required(ErrorMessage = "status  is Required")]
        public string status { get; set; }
        [Required(ErrorMessage = "session  is Required")]
        public int  SesssionId { get; set; }
       
        public ClassesSessions? Sessions { get; set; }
        public ICollection<SchoolSubjects>? Subjects { get; set; }
    }
}
