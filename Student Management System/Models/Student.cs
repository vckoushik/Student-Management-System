﻿using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Models
{
    public class Student : SystemUser
    {
        [Key]
        [Required]
        public string Id { get; set; }

        public string MiddleName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        public Address Address{ get; set; }
        public double GPA { get; set; }
        public string Major { get; set; }
        public int ResumeId { get; set; }
    }
}
