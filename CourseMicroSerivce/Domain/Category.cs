using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseMicroSerivce.Domain
{
    [Table("Category")]
    public class Category : CourseContent
    {
        public virtual ICollection<Courses> Courses { get; set; }
    }
}
