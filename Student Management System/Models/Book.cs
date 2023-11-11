using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Models
{
    public class Book
    {
        [Key]
        public int BNo { get; set; }    // Book Number
        public string BName { get; set; } // Book Name
        public DateTime Date { get; set; } // Date Published
        public string Status { get; set; } // Book Status
        public string Author { get; set; } // Author Name
    }

}
