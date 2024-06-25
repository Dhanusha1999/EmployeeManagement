﻿using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Gender
    {
        [Key]
        public int GenderId {  get; set; }
        [Required]
        public string GenderName { get; set; }
    }
}