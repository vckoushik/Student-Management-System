
using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Models
{
    public class Resume
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public double GPA { get; set; }
        public string Major { get; set; }
        public int ResumeId { get; set; }
        public List<Education> Education { get; set; }
        public List<Experience> Experiences { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Certification> Certifications { get; set; }
        public List<Project> Projects { get; set; }

        public Resume()
        {
           
            Education = new List<Education>();
            Experiences = new List<Experience>();
            Skills = new List<Skill>();
            Certifications = new List<Certification>();
            Projects = new List<Project>();
        }
    }
}
