namespace CourseMicroSerivce.Models.AutoMapperDTOS
{
    public class StudentDto
    {
        public string   FirstName { get; set; }
        public string   LastName  { get; set; }
        public string   Email     { get; set; }
        public string   Password  { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string   image { get; set; }
        public string   AddressLine1 { get; set; }
        public string   AddressLine2 { get; set; }
        public string   zipCode { get; set; }
        public string   city { get; set; }
        public string   country { get; set; }
        public string   phone { get; set; }


    }
}
