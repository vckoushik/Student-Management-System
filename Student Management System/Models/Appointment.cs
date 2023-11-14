namespace Student_Management_System.Models
{

    public class Appointment
    {
        public int Id { get; set; }

        public string StudentId { get; set; } 

        public string AdvisorId { get; set; } 

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Location { get; set; }

        public string Purpose { get; set; }

    }

}
