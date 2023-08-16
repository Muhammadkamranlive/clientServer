using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CourseMicroSerivce.Domain.TeacherPortal
{
    public class PermissionManagment
    {
        public int Id             { get; set; }
        [Required(ErrorMessage = "status  is Required")]
        public string status      { get; set; }
       
        [Required(ErrorMessage = "Class is Required")]
        public int ClassId        { get; set; }
        public int? SubjectId     { get; set; }
        [Required(ErrorMessage = "Teacher   is Required")]
        public string TeacherId  { get; set; }

    }
}
