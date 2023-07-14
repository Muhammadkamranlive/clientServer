using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseMicroSerivce.Domain
{
    [Table("Tags")]
    public class Tags : CourseContent
    {
    }
}
