using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Models
{
    public class Registration
    {
        [Key]
        public int Id { get; set; }
        public Student student { get; set; }
        public Course course { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
