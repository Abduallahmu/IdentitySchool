using IdentitySchool.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdentitySchool.ViewModels
{
    public class StudentVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Location { get; set; }

        public List<StudentsCourses> StudentsCourses { get; set; }

        public List<Course> Courses { get; set; }

        public List<Assignment> Assignments { get; set; }
    }
}
