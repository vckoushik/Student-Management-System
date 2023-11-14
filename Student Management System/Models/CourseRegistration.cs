using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Models
{
    public class CourseRegistration
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public int CourseId { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        // Additional properties as needed

        // Navigation properties
        public virtual SystemUser Student { get; set; }

        public virtual Course Course { get; set; }
    }
}
