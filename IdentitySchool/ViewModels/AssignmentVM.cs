using IdentitySchool.Models;
using System.Collections.Generic;

namespace IdentitySchool.ViewModels
{
    public class AssignmentVM
    {
        public List<Assignment> Assignments { get; set; }

        public int Id { get; set; }

        public int CourseId { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
