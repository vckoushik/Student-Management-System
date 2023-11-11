using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public string Location { get; set; }
        public string Time { get; set; }
        public DateTime Date { get; set; }
    }

}
