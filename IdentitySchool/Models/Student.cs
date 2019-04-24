using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdentitySchool.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Location { get; set; }

        public List<StudentsCourses> StudentsCourses { get; set; }
    }
}
