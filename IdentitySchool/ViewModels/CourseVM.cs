using IdentitySchool.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdentitySchool.ViewModels
{
    public class CourseVM
    {
        public int CourseId { get; set; }
        [Required]
        public string Title { get; set; }

        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public int TeacherId { get; set; }

        public int AssiId { get; set; }

        public List<Teacher> Teachers { get; set; }

        public List<Course> Courses { get; set; }

        public List<Assignment> Assignments { get; set; }

    }
}
