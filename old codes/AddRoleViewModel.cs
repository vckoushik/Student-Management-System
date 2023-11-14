using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Models
{
    public class AddRoleViewModel
    {
        [Required]
        [Display(Name = "Role")]
        public string RoleName { get; set; }
    }
}
