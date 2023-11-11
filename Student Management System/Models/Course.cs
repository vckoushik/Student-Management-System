using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int EnrollmentCount { get; set; }
        public int TotalSeats { get; set; }
        public string RoomNumber { get; set; }
        public string Timings { get; set; }
        public string ProfessorName { get; set; }
    }
}
