using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdentitySchool.Models
{
    public class Assignment
    {
        public int AssignmentId { get; set; }
        
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public int CourseId { get; set; }
    }
}
