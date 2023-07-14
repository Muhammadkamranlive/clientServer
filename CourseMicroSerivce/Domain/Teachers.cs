using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseMicroSerivce.Domain
{
    [Table("Teachers")]
    public class Teachers : Person
    {
        public double Salary { get; set; }
        public virtual ICollection<Students> Students { get; set; }
        public virtual ICollection<Courses> Courses { get; set; }
    }
}
