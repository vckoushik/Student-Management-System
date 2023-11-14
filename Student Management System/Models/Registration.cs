using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Models
{
    public class Registration
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public Course Course { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Status { get; set; }
    }
}
