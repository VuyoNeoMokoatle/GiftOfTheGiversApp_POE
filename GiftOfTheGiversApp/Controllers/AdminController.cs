using GiftOfTheGiversApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GiftOfTheGiversApp.Controllers
{
    [Authorize] // only logged-in users (later we restrict to Admins)
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Messages()
        {
            var messages = _context.ContactMessages
                                   .OrderByDescending(m => m.SentAt)
                                   .ToList();
            return View(messages);
        }
    }
}
