using System.Diagnostics;
using GiftOfTheGiversApp.Models;
using GiftOfTheGiversApp.Data;   // ✅ Needed for DbContext
using Microsoft.AspNetCore.Mvc;

namespace GiftOfTheGiversApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context; // ✅ Database context

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // ✅ NEW: About page
        public IActionResult About()
        {
            return View();
        }

        // ✅ NEW: Contact page (GET)
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        // ✅ NEW: Contact page (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Contact(ContactMessage model)
        {
            if (ModelState.IsValid)
            {
                _context.ContactMessages.Add(model);
                _context.SaveChanges();
                ViewBag.SuccessMessage = "✅ Thank you for contacting us! We’ll respond soon.";
                return View();
            }

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
