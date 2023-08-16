using CourseMicroSerivce.Domain.AuthenticationModels;
using System.ComponentModel.DataAnnotations;

namespace CourseMicroSerivce.Domain.TeacherPortal
{
    public class SchoolSubjects
    {
        public SchoolSubjects()
        {
            SubjectThemes = new HashSet<SchoolThemes>();
        }
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Name /Title  is Required")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Icon /Image  is Required")]
        public string image { get; set; }
        
        [Required(ErrorMessage = "status  is Required")]
        public string Status { get; set; }

        [Required(ErrorMessage = "class  is Required")]
        public int ClassId { get; set; }

        public Teacher? Teachers { get; set; }
        public ICollection<SchoolThemes>? SubjectThemes  { get; set; }
    }
}
