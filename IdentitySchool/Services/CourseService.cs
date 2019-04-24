using IdentitySchool.Interface;
using IdentitySchool.Models;
using IdentitySchool.SchoolDb;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace IdentitySchool.Services

{
    public class CourseService : ICourseService
    {
        readonly SchoolDbContext _schoolDbContext;

        public CourseService(SchoolDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
        }

        public List<Course> AllCourse()
        {                           
            return _schoolDbContext.Courses
                .Include(cCoruser => cCoruser.Teacher)
                .Include(cCoruser => cCoruser.StudentsCourses)
                .ThenInclude(cCoruser => cCoruser.Student)
                .Include(cCoruser => cCoruser.Assignments)
                .ToList();
        }
        public Course CreateCourse(string title, string description)
        {
            Course course = new Course()
            {   Title = title,
                Description = description
            };          

            _schoolDbContext.Courses.Add(course);
            _schoolDbContext.SaveChanges();
            return course;
        }

        public bool DeleteCourse(int id)
        {
            bool wasRemoved = false;

            Course course = _schoolDbContext.Courses.Include(singel => singel.Assignments).SingleOrDefault(courses => courses.CourseId == id);
            if (course == null)
            {
                return wasRemoved;
            }

            _schoolDbContext.Courses.Remove(course);
            _schoolDbContext.SaveChanges();
            return wasRemoved;
        }

        public Course FindCourse(int id)
        {
            var course = _schoolDbContext.Courses
                .Include(cCoruser => cCoruser.Teacher)
                .Include(cCoruser => cCoruser.StudentsCourses)
                .Include("StudentsCourses.Student")
                .Include(cCoruser => cCoruser.Assignments)
                .SingleOrDefault(courses => courses.CourseId == id);

            return course;
        }

        public bool UpdateCourse(Course course)
        {
            bool wasUpdate = false;

            Course oldCourse = FindCourse(course.CourseId);

            if (oldCourse != null)
            {
                oldCourse.Title = course.Title;
                oldCourse.Description = course.Description;
                
                if (course.Teacher != null)
                {
                    oldCourse.Teacher = course.Teacher;
                }

                if (course.StudentsCourses != null)
                {
                    oldCourse.StudentsCourses = course.StudentsCourses;
                }

                if (course.Assignments != null)
                {
                    oldCourse.Assignments = course.Assignments;
                }

                _schoolDbContext.SaveChanges();
                wasUpdate = true;
            }

            return wasUpdate;
        }

        public void AddStudentToCourse(Course course, Student student)
        {
            course.StudentsCourses.Add(new StudentsCourses() { StudentId = student.Id, CourseId = course.CourseId, Course = course, Student = student });

            _schoolDbContext.SaveChanges();
        }

        public bool RemoveStudentToCourse(Course course, int studentId)
        {
            foreach (var item in course.StudentsCourses)
            {
                if (item.StudentId == studentId)
                {
                    course.StudentsCourses.Remove(item);

                    _schoolDbContext.SaveChanges();

                    return true;
                }
            }
            return false;
        }
    }
}
