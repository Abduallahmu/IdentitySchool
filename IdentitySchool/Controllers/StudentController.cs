using IdentitySchool.Interface;
using IdentitySchool.Models;
using Microsoft.AspNetCore.Mvc;

namespace IdentitySchool.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _student;

        public StudentController(IStudentService student)
        {
            _student = student;
        }

        public IActionResult Index()
        {
            return View(_student.AllStudents());
        }

        [HttpGet]
        public IActionResult CreateStudent()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateStudent([Bind("Name,Phone,Location")]Student student)
        {
            if (ModelState.IsValid)
            {
                student = _student.CreateStudent(student.Name, student.Phone, student.Location);
                return RedirectToAction(nameof(Index));
            }

            return View(student); 
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var student = _student.FindStudent((int)id);
            if (student == null)
            {
                return NotFound();
            }



            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {

            if (ModelState.IsValid)
            {
                _student.UpdateStudent(student);
                return RedirectToAction(nameof(Index));

            }
            return View(student);
        }
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                _student.DeleteStudent((int)id);
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
            var student = _student.FindStudent((int)id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
    }
}