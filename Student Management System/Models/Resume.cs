using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Models
{
    public class Resume
    {
        [Key]
        public int Id { get; set; }
        public Student student { get; set; }
        public string Details { get; set; }
        public string ResumeLoc { get; set; }
    }
}
