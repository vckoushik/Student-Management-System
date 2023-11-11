using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PostedOn { get; set; }
        public string LinkToJob { get; set; }
    }

}
