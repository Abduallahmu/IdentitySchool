using IdentitySchool.Models;
using System.Collections.Generic;

namespace IdentitySchool.Interface
{
    public interface IAssignmentService
    {
        Assignment CreateAssignment(Assignment assignment);

        List<Assignment> AllAssignment();

        Assignment FindAssignment(int id);

        bool UpdateAssignment(Assignment assignment);

        bool DeleteAssignment(int id);
        //Assignment CreateAssignment(string description, string title);
    }
}
