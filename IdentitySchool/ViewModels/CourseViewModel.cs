using IdentitySchool.Models;
using System.Collections.Generic;

namespace IdentitySchool.ViewModels
{
    public class CourseViewModel
    {
        
        public List<Teacher> Teachers = new List<Teacher>();

        public List<Student> Students = new List<Student>();

        public List<Assignment> Assignments = new List<Assignment>();

        public Course Course { get; set; }

        public Course Teacher { get; set; }

    }
}
