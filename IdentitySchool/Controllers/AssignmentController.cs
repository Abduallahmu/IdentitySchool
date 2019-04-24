using IdentitySchool.Interface;
using IdentitySchool.Models;
using IdentitySchool.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IdentitySchool.Controllers
{
    public class AssignmentController : Controller
    {
        private readonly IAssignmentService _assignmentService;

        public AssignmentController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var assignment = _assignmentService.FindAssignment((int)id);
            if (assignment == null)
            {
                return Content("");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Assignment assignment)
        {

            if (ModelState.IsValid)
            {
                _assignmentService.UpdateAssignment(assignment);
                return RedirectToAction(nameof(Assignment));

            }
            return Content("");
        }
        
    }
}