using System.ComponentModel.DataAnnotations.Schema;

namespace WorkTimeRegistration.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Postition { get; set; }

        public virtual Address Address { get; set; }
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
    }
}
