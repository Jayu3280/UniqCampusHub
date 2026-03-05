using Microsoft.AspNetCore.Mvc;

namespace UniqCampusHub.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}