using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GiftOfTheGiversApp.Data;
using GiftOfTheGiversApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace GiftOfTheGiversApp.Controllers
{
    [Authorize]
    public class ReliefProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReliefProjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ReliefProjects
        public async Task<IActionResult> Index()
        {
            var projects = await _context.ReliefProjects.ToListAsync();
            return View(projects);
        }

        // GET: ReliefProjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var reliefProject = await _context.ReliefProjects
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (reliefProject == null) return NotFound();

            return View(reliefProject);
        }

        // GET: ReliefProjects/Create
        public IActionResult Create() => View();

        // POST: ReliefProjects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectId,ProjectName,Location,StartDate,EndDate")] ReliefProject reliefProject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reliefProject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reliefProject);
        }

        // GET: ReliefProjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var reliefProject = await _context.ReliefProjects.FindAsync(id);
            if (reliefProject == null) return NotFound();

            return View(reliefProject);
        }

        // POST: ReliefProjects/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectId,ProjectName,Location,StartDate,EndDate")] ReliefProject reliefProject)
        {
            if (id != reliefProject.ProjectId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reliefProject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReliefProjectExists(reliefProject.ProjectId)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(reliefProject);
        }

        // GET: ReliefProjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var reliefProject = await _context.ReliefProjects
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (reliefProject == null) return NotFound();

            return View(reliefProject);
        }

        // POST: ReliefProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reliefProject = await _context.ReliefProjects.FindAsync(id);
            if (reliefProject != null)
            {
                _context.ReliefProjects.Remove(reliefProject);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ReliefProjectExists(int id) =>
            _context.ReliefProjects.Any(e => e.ProjectId == id);
    }
}

