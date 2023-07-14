using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseMicroSerivce.Models.AutoMapperDTOS
{
    public class CoursesDTO : CourseCotentDTOS
    {
        public int Price { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public int NumberOfLectures { get; set; }
        public int CoverID { get; set; }


    }
}
