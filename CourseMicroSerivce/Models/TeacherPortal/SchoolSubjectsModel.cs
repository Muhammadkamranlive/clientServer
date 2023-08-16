

using System.ComponentModel.DataAnnotations;

namespace CourseMicroSerivce.Models.TeacherPortal
{
    public class SchoolSubjectsModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name /Title  is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Icon /Image  is Required")]
        public string image { get; set; }

        [Required(ErrorMessage = "status  is Required")]
        public string Status { get; set; }

        [Required(ErrorMessage = "class  is Required")]
        public int ClassId { get; set; }

    }
}
