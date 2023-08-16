

using System.ComponentModel.DataAnnotations;

namespace CourseMicroSerivce.Models.TeacherPortal
{
    public class SchoolClassesModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name / Title  is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "status  is Required")]
        public string status { get; set; }
        [Required(ErrorMessage = "session  is Required")]
        public int SesssionId { get; set; }

    }
}
