using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseMicroSerivce.Domain
{
    [Table("Students")]
    public class Students : Person
    {
        public double Gpa { get; set; }
        public virtual ICollection<Courses> Courses { get; set; }
        public virtual ICollection<Teachers> Teachers { get; set; }
    }
}
