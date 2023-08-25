namespace CourseMicroSerivce.Domain.AuthenticationModels
{
    public class Teacher:ApplicationUser
    {
        public DateTime ExpirationDate { get; set; }
        public DateTime startingDate { get; set; }
        public string language { get; set; }
    }
}
