using System.Collections.Generic;
using IdentitySchool.Interface;
using IdentitySchool.Models;
using IdentitySchool.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace IdentitySchool.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly ITeacherService _teacherService;
        private readonly IAssignmentService _assignmentService;
        private readonly IStudentService _studentService;



        public CourseController(ICourseService courseService, ITeacherService teacherService, IAssignmentService assignmentService, IStudentService studentService)
        {
            _courseService = courseService;
            _teacherService = teacherService;
            _assignmentService = assignmentService;
            _studentService = studentService;
        }

        public IActionResult Index()
        {
            return View(_courseService.AllCourse());
        }

        public IActionResult CreateCourse()
        {
            return View();
        }

        public IActionResult CreateAssignment(int courseId)
        {
            var vm = new AssignmentVM
            {
                CourseId = courseId
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCourse([Bind("Title, Description")] Course course)
        {
            if (ModelState.IsValid)
            {
                course = _courseService.CreateCourse(course.Title, course.Description);
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAssignment(Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                _assignmentService.CreateAssignment(assignment);

                return RedirectToAction(nameof(Details), new { id = assignment.CourseId });
            }
            return View(assignment);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var course = _courseService.FindCourse((int)id);
            if (course == null)
            {
                return NotFound();
            }
            CourseVM name = new CourseVM
            {
                CourseId = course.CourseId,
                Title = course.Title,
                Description = course.Description,
                Teachers = _teacherService.AllTeacher(),
            };
            return View(name);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CourseVM course)
        {
            if (ModelState.IsValid)
            {
                var teacherF = _teacherService.FindTeacher(course.TeacherId);

                var courseToUpdate = new Course
                {
                    Title = course.Title,
                    Description = course.Description,
                    Teacher = teacherF,
                    CourseId = course.CourseId
                };
                _courseService.UpdateCourse(courseToUpdate);
                return RedirectToAction(nameof(Index));
            }

            CourseViewModel CourseViewModel = new CourseViewModel();           

            return View(course);
        }

        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                _courseService.DeleteCourse((int)id);
                _assignmentService.DeleteAssignment((int)id);
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
            var course = _courseService.FindCourse((int)id);

            if (course == null)
            {
                return NotFound();
            }

            CourseViewModel CourseViewModel = new CourseViewModel();
            CourseViewModel.Course = course;

            CourseViewModel.Assignments = course.Assignments;


            List<Student> studentsNotInCourse = _studentService.AllStudents();

            foreach (var item in course.StudentsCourses)
            {
                studentsNotInCourse.Remove(item.Student);
            }

            CourseViewModel.Students = studentsNotInCourse;

            return View(CourseViewModel);
        }
        public IActionResult AddStudentToCourseSave(int cId, int sId)
        {
            var course = _courseService.FindCourse(cId);
            if (course == null)
            {
                return NotFound();
            }

            var student = _studentService.FindStudent(sId);
            if (student == null)
            {
                return NotFound();
            }

            foreach (var item in course.StudentsCourses)
            {
                if (item.StudentId == sId)
                {
                    return RedirectToAction(nameof(Details), new { id = cId });
                }
            }

            _courseService.AddStudentToCourse(course,student);    

            return RedirectToAction(nameof(Details), new { id = cId });
        }

        public IActionResult RemoveStudentToCourse(int cId, int sId)
        {
            var course = _courseService.FindCourse(cId);
            if (course == null)
            {
                return NotFound();
            }

            _courseService.RemoveStudentToCourse(course, sId);

            return RedirectToAction(nameof(Details), new { id = cId });
        }

        public IActionResult DeleteAssignment(int? id, int courseId)
        {
            if (id != null)
            {
                _assignmentService.DeleteAssignment((int)id);
                return RedirectToAction(nameof(Details), new { id = courseId });
            }
            return Content("");
        }
    }
}