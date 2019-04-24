using IdentitySchool.Models;
using System.Collections.Generic;

namespace IdentitySchool.Interface
{
    public interface IStudentService
    {
        Student CreateStudent(string name, string phone, string location);

        List<Student> AllStudents();

        Student FindStudent(int id);

        bool UpdateStudent(Student student);

        bool DeleteStudent(int id);
    }
}
