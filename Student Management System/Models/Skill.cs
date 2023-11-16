﻿using System.ComponentModel.DataAnnotations;

namespace Student_Management_System.Models
{
    public class Skill
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; }
        public int ResumeId { get; set; }
        public Resume Resume { get; set; }
    }
}