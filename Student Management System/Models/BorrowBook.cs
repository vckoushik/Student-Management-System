using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Models
{
    public class BorrowBook
    {
        [Key]
        public int BorrowID { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool Status { get; set; }
        public string RequestStatus { get; set; }

        // Navigation properties
        public int BookNo { get; set; }
        public string UserId { get; set; }
    }
}
