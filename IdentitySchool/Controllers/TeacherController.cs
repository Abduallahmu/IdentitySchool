using IdentitySchool.Interface;
using IdentitySchool.Models;
using Microsoft.AspNetCore.Mvc;

namespace IdentitySchool.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        public IActionResult Index()
        {
            return View(_teacherService.AllTeacher());
        }

        [HttpGet]
        public IActionResult CreateTeacher()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTeacher([Bind("Name,Description")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                teacher = _teacherService.CreateTeacher(teacher.Name, teacher.Description);
                return RedirectToAction(nameof(Index));
            }

            return View(teacher);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var teacher = _teacherService.FindTeacher((int)id);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Teacher teacher)
        {

            if (ModelState.IsValid)
            {
                _teacherService.UpdateTeacher(teacher);
                return RedirectToAction(nameof(Index));

            }
            return View(teacher);
        }
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                _teacherService.DeleteTeacher((int)id);
                return RedirectToAction(nameof(Index));
            }
            return Content("");
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var teacher = _teacherService.FindTeacher((int)id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }
    }
}