using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdentitySchool.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        public Teacher Teacher { get; set; }

        public List<StudentsCourses> StudentsCourses { get; set; }

        public List<Assignment> Assignments { get; set; }

    }
}
