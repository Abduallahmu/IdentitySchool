using IdentitySchool.Models;
using System.Collections.Generic;

namespace IdentitySchool.Interface
{
    public interface ICourseService
    {
        Course CreateCourse(string name, string description);

        List<Course> AllCourse();

        Course FindCourse(int id);

        bool UpdateCourse(Course Course);

        bool DeleteCourse(int id);
        void AddStudentToCourse(Course course, Student student);

        bool RemoveStudentToCourse(Course course, int studentId);
    }
}
