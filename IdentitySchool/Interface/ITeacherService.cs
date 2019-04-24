using IdentitySchool.Models;
using System.Collections.Generic;

namespace IdentitySchool.Interface
{
    public interface ITeacherService
    {
        Teacher CreateTeacher(string name, string description);

        List<Teacher> AllTeacher();

        Teacher FindTeacher(int id);

        bool UpdateTeacher(Teacher teacher);

        bool DeleteTeacher(int id);
    }
}
