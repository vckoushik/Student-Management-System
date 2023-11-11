using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string AptNum { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
