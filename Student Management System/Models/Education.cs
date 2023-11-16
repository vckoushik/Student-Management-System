using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Models
{
    public class Education
    {
        [Key]
        public int Id { get; set; }
        public string Degree { get; set; }
        public string Institution { get; set; }
        public string Year { get; set; }
        public string Description { get; set; }
        public int ResumeId { get; set; }
        public Resume Resume { get; set; }
    }
}