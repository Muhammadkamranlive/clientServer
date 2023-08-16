using System.ComponentModel.DataAnnotations;

namespace CourseMicroSerivce.Domain.TeacherPortal
{
    public class SchoolThemes
    {
        public SchoolThemes()
        {
            Chapters = new HashSet<SchoolChapters>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Name /Title  is Required")]
        public string Name { get; set; }
        public string? image { get; set; }

        [Required(ErrorMessage = "status  is Required")]
        public string status { get; set; }

        [Required(ErrorMessage = "Subject  is Required")]
        public int SubjectId { get; set; }
        public ICollection<SchoolChapters>? Chapters { get; set; }
        


    }
}
