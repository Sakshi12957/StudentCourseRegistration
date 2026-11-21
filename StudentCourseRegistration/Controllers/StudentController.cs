
using Microsoft.AspNetCore.Mvc;
using StudentCourseRegistration.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudentCourseRegistration.Controllers
{
    public class StudentController : Controller
    {
        // Temporary in-memory student list
        private static List<Student> students = new List<Student>();

        // Display student list
        public IActionResult Index()
        {
            return View(students);
        }

        // Open registration form
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Save student details
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                student.Id = students.Count == 0
                    ? 1
                    : students.Max(s => s.Id) + 1;

                students.Add(student);

                return RedirectToAction("Index");
            }

            return View(student);
        }

        // Display individual student details
        public IActionResult Details(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }
    }
}
