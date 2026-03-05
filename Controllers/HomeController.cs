using Microsoft.AspNetCore.Mvc;
using UniqCampusHub.Data;
using UniqCampusHub.Models;

namespace UniqCampusHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string username, string password)
        {
            var user = _context.Professors
                        .FirstOrDefault(x => x.Username == username && x.Password == password);

            if (user != null)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            ViewBag.Error = "Invalid username or password";
            return View();
        }

        // ✅ GET: Register
        public IActionResult Register()
        {
            return View();
        }

        // ✅ POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Professor professor)
        {
            if (ModelState.IsValid)
            {
                _context.Professors.Add(professor);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(professor);
        }
    }
}