﻿using System.ComponentModel.DataAnnotations;

namespace CourseMicroSerivce.Domain.TeacherPortal
{
    public class CoursePosts
    {
        
        public int    Id                    { get; set; }
        [Required(ErrorMessage = "Title  is Required")]
        public string Title                 { get; set; }
        [Required(ErrorMessage = "status  is Required")]
        public string status                { get; set; }
        [Required(ErrorMessage = "Description  is Required")]
        public string Description           { get; set; }
        [Required(ErrorMessage = "Course    is Required")]
        public int    SchoolCourseId        { get; set; }
        public SchoolCourses? SchoolCourses { get; set; }
       
        

    }
}
