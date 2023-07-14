using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseMicroSerivce.Domain
{
    [Table("Courses")]
    public class Courses : CourseContent
    {
        public int Price { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public int NumberOfLectures { get; set; }
        public int CoverID { get; set; }

        public virtual ICollection<Students> Students { get; set; }
        public virtual ICollection<Teachers> Teachers { get; set; }
        public virtual Category Categories { get; set; }
        public virtual ICollection<Tags> Tags { get; set; }
    }
}
