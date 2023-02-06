namespace WorkTimeRegistration.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string SreetName { get; set; }
        public string HouseNumber { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }

        public int EmpoleyyId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
