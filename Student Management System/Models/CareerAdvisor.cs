using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Models
{
    public class CareerAdvisor
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
