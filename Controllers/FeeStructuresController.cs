using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniqCampusHub.Data;
using UniqCampusHub.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UniqCampusHub.Controllers
{
    public class FeeStructuresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FeeStructuresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FeeStructures
        public async Task<IActionResult> Index()
        {
            return View(await _context.FeeStructures.ToListAsync());
        }

        // GET: FeeStructures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var feeStructure = await _context.FeeStructures
                .FirstOrDefaultAsync(m => m.Id == id);

            if (feeStructure == null) return NotFound();

            return View(feeStructure);
        }

        // GET: FeeStructures/Create
        public IActionResult Create()
        {
            // Pass students list for dropdown
            ViewBag.Students = new SelectList(_context.Students.ToList(), "Id", "Name");
            return View();
        }

        // POST: FeeStructures/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int StudentId, decimal TotalFee, decimal CollectedFee)
        {
            var student = await _context.Students.FindAsync(StudentId);
            if (student == null)
            {
                ModelState.AddModelError("", "Selected student not found.");
                ViewBag.Students = new SelectList(_context.Students.ToList(), "Id", "Name", StudentId);
                return View();
            }

            var feeStructure = new FeeStructure
            {
                StudentName = student.Name,
                RollNumber = student.RollNumber,
                TotalFee = TotalFee,
                CollectedFee = CollectedFee,
                RemainingFee = TotalFee - CollectedFee
            };

            _context.FeeStructures.Add(feeStructure);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        // GET: FeeStructures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var feeStructure = await _context.FeeStructures.FindAsync(id);
            if (feeStructure == null) return NotFound();

            // Optional: reload students if needed
            ViewBag.Students = new SelectList(_context.Students.ToList(), "Id", "Name");
            return View(feeStructure);
        }

        // POST: FeeStructures/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FeeStructure feeStructure)
        {
            if (id != feeStructure.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    // Recalculate RemainingFee
                    feeStructure.RemainingFee = feeStructure.TotalFee - feeStructure.CollectedFee;

                    _context.Update(feeStructure);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeeStructureExists(feeStructure.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(feeStructure);
        }

        // GET: FeeStructures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var feeStructure = await _context.FeeStructures
                .FirstOrDefaultAsync(m => m.Id == id);

            if (feeStructure == null) return NotFound();

            return View(feeStructure);
        }

        // POST: FeeStructures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var feeStructure = await _context.FeeStructures.FindAsync(id);
            if (feeStructure != null)
            {
                _context.FeeStructures.Remove(feeStructure);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool FeeStructureExists(int id)
        {
            return _context.FeeStructures.Any(e => e.Id == id);
        }
    }
}