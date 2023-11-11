using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Models
{
    public class UniversityUpdate
    {   
            [Key]
            public int UpdateId { get; set; }
            public string UpdateName { get; set; }
            public string Description { get; set; }
            public DateTime Date { get; set; }
        
    }
}
