﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdentitySchool.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public List<Course> Courses { get; set; }
    }
}
