using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseMicroSerivce.Domain
{
    [Table("CourseContent")]
    public class CourseContent
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
