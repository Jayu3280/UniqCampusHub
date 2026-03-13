using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniqCampusHub.Data;
using UniqCampusHub.Models;

namespace UniqCampusHub.Controllers
{
    public class AttendancesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AttendancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Attendances/Index  
        public IActionResult Index()
        {
            var students = _context.Students.ToList();
            ViewBag.Students = students;

            // Empty attendance list for model binding  
            var model = students.Select(s => new Attendance { StudentName = s.Name }).ToList();
            return View(model);
        }

        // POST: /Attendances/Create  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(List<Attendance> attendances)
        {
            if (attendances != null && attendances.Count > 0)
            {
                foreach (var att in attendances)
                {
                    _context.Attendances.Add(att);
                }
                _context.SaveChanges();
                ViewBag.Message = "Attendance Submitted Successfully!";
            }

            ViewBag.Students = _context.Students.ToList();
            return View("Index", attendances);
        }


    }

}