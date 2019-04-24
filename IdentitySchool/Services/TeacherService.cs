using IdentitySchool.Interface;
using IdentitySchool.Models;
using IdentitySchool.SchoolDb;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace IdentitySchool.Services

{
    public class TeacherService : ITeacherService
    {
        readonly SchoolDbContext _schoolDbContext;

        public TeacherService(SchoolDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
        }

        public List<Teacher> AllTeacher()
        {
            return _schoolDbContext.Teachers
                .Include(c => c.Courses)
                .ToList();
        }

        public Teacher CreateTeacher(string name, string description)
        {
            Teacher teacher = new Teacher() { Name = name, Description = description };

            _schoolDbContext.Teachers.Add(teacher);
            _schoolDbContext.SaveChanges();
            return teacher;
        }

        public bool DeleteTeacher(int id)
        {
            bool wasRemoved = false;

            Teacher teacher = _schoolDbContext.Teachers.SingleOrDefault(g => g.Id == id);

            if (teacher == null)
            {
                return wasRemoved;
            }

            _schoolDbContext.Teachers.Remove(teacher);
            _schoolDbContext.SaveChanges();
            return wasRemoved;
        }

        public Teacher FindTeacher(int id)
        {
            return _schoolDbContext.Teachers
                .Include(f => f.Courses)
                .SingleOrDefault(teachers => teachers.Id == id);

        }

        public bool UpdateTeacher(Teacher teacher)
        {
            bool wasUpdate = false;
            Teacher stud = _schoolDbContext.Teachers
                .Include(c => c.Courses)
                .SingleOrDefault(teachers => teachers.Id == teacher.Id);
            {
                if (stud != null)
                {
                    stud.Name = teacher.Name;
                    stud.Description = teacher.Description;

                    if (teacher.Courses != null)
                    {
                        stud.Courses = teacher.Courses;
                    }

                    _schoolDbContext.SaveChanges();
                    wasUpdate = true;
                }
            }
            return wasUpdate;
        }
    }
}
