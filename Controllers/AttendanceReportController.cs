using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniqCampusHub.Data;
using UniqCampusHub.Models;

namespace UniqCampusHub.Controllers
{
    public class AttendanceReportController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AttendanceReportController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /AttendanceReport/Index
        public IActionResult Index()
        {
            // Get all students from database
            var students = _context.Students.ToList();

            // Pass the list as the model to the view
            return View(students);
        }
        // POST: /AttendanceReport/ViewReport
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ViewReport(int studentId)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == studentId);
            if (student == null)
                return NotFound();

            var attendances = _context.Attendances
                                .Where(a => a.StudentName == student.Name)
                                .ToList();

            int totalDays = attendances.Count;
            int presentDays = attendances.Count(a => a.IsPresent);
            int absentDays = totalDays - presentDays;
            double percentage = totalDays > 0 ? (presentDays * 100.0) / totalDays : 0;

            var report = new AttendanceReport
            {
                StudentName = student.Name,
                TotalDays = totalDays,
                PresentDays = presentDays,
                AbsentDays = absentDays,
                AttendancePercentage = percentage
            };

            return View("ViewReport", report);
        }
    }
}