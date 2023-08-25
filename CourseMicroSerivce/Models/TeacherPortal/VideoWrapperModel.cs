namespace CourseMicroSerivce.Models.TeacherPortal
{
    public class VideoWrapperModel
    {
        
            public string Title { get; set; }
            public string Status { get; set; }
            public IFormFile VideoFile { get; set; } // To upload video file
            public int SchoolCourseId { get; set; }
           
        
    }
}
