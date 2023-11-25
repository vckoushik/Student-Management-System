using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string CompanyLogo { get; set; }
        public DateTime PostedOn { get; set; }
        public string LinkToJob { get; set; }
    }

}
