using IdentitySchool.Interface;
using IdentitySchool.Models;
using IdentitySchool.SchoolDb;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace IdentitySchool.Services
{
    public class AssignmentService : IAssignmentService
    {
        readonly SchoolDbContext _schoolDbContext;

        public AssignmentService(SchoolDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
        }

        public List<Assignment> AllAssignment()
        {
            return _schoolDbContext.Assignments.ToList();
        }
        public Assignment CreateAssignment(Assignment assignment)
        {
            _schoolDbContext.Assignments.Add(assignment);

            _schoolDbContext.SaveChanges();

            return assignment;
        }

        public bool DeleteAssignment(int id)
        {
            bool wasRemoved = false;

            Assignment assignment = _schoolDbContext.Assignments.SingleOrDefault(gg => gg.AssignmentId == id);

            if (assignment == null)
            {
                return wasRemoved;
            }

            _schoolDbContext.Assignments.Remove(assignment);
            _schoolDbContext.SaveChanges();

            return wasRemoved;
        }

        public Assignment FindAssignment(int id)
        {
            return _schoolDbContext.Assignments.SingleOrDefault(dd => dd.AssignmentId == id);
        }

        public bool UpdateAssignment(Assignment assignment)
        {
            bool wasUpdate = false;

            Assignment qqq = _schoolDbContext.Assignments.SingleOrDefault(yy => yy.AssignmentId == assignment.AssignmentId);//Najti i ydalit

            if (qqq != null)
            {
                return wasUpdate;
            }

            _schoolDbContext.Assignments.Remove(qqq);
            _schoolDbContext.SaveChanges();

            return wasUpdate;
        }

    }
}
