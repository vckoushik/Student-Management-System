using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Models
{
    public class Experience
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Year { get; set; }
        public string Description { get; set; }
        public int ResumeId { get; set; }
        public Resume Resume { get; set; }
    }
}