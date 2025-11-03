using Microsoft.AspNetCore.Mvc;
using GiftOfTheGiversApp.Data;
using System.Linq;

namespace GiftOfTheGiversApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReliefProjectsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReliefProjectsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var projects = _context.ReliefProjects
                .Select(p => new
                {
                    p.ProjectId,
                    p.ProjectName,
                    p.Location,
                    p.StartDate,
                    p.EndDate
                }).ToList();

            return Ok(projects);
        }
    }
}


