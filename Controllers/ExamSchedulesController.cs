using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using UniqCampusHub.Data;
using UniqCampusHub.Models;
using System.Collections.Generic;
using System.Linq;

namespace UniqCampusHub.Controllers
{
    public class ExamSchedulesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExamSchedulesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // List all exam schedules
        public IActionResult Index()
        {
            var schedules = _context.ExamSchedules.ToList();
            return View(schedules);
        }

        // GET: ExamSchedules/Create or Edit (Unified form)
        public IActionResult Create()
        {
            ViewBag.Subjects = GetSubjects();
            return View("ExamForm", new ExamSchedule());
        }

        public IActionResult Edit(int id)
        {
            var exam = _context.ExamSchedules.Find(id);
            if (exam == null) return NotFound();

            ViewBag.Subjects = GetSubjects();
            return View("ExamForm", exam);
        }

        // POST: ExamSchedules/Save (Handles both Create & Edit)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(ExamSchedule model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Subjects = GetSubjects();
                return View("ExamForm", model);
            }

            if (model.Id == 0)
                _context.ExamSchedules.Add(model);
            else
                _context.ExamSchedules.Update(model);

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: ExamSchedules/Details/5
        public IActionResult Details(int id)
        {
            var exam = _context.ExamSchedules.Find(id);
            if (exam == null) return NotFound();

            return View(exam); // Use Details.cshtml view
        }

        // GET: ExamSchedules/Delete/5
        public IActionResult Delete(int id)
        {
            var exam = _context.ExamSchedules.Find(id);
            if (exam == null) return NotFound();

            return View(exam); // Use Delete.cshtml view
        }

        // POST: ExamSchedules/DeleteConfirmed
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var exam = _context.ExamSchedules.Find(id);
            if (exam == null) return NotFound();

            _context.ExamSchedules.Remove(exam);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // ✅ Download PDF timetable
        public IActionResult DownloadTimetable()
        {
            var schedules = _context.ExamSchedules.ToList();

            return new ViewAsPdf("TimetablePdf", schedules)
            {
                FileName = "ExamTimetable.pdf",
                PageSize = Rotativa.AspNetCore.Options.Size.A4,
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape,
                CustomSwitches = "--disable-smart-shrinking"
            };
        }

        // Private helper to get subject list
        private List<string> GetSubjects()
        {
            return new List<string>
            {
                "C#",
                "C#(Practical)",
                "Java Programming",
                "Java Programming (Practical)",
                "Python",
                "Python (Practical)"
            };
        }
    }
}