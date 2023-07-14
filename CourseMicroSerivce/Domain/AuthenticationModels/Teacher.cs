namespace CourseMicroSerivce.Domain.AuthenticationModels
{
    public class Teacher:ApplicationUser
    {
        public DateTime LoginEndDate { get; set; }
    }
}
