namespace CourseMicroSerivce.Domain.AuthenticationModels
{
    public class Teacher:ApplicationUser
    {
        public DateTime ExpirationDate { get; set; }
        
    }
}
