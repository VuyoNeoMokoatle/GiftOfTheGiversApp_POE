using Xunit;
using GiftOfTheGiversApp.Controllers;
using GiftOfTheGiversApp.Data;
using GiftOfTheGiversApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GiftOfTheGiversApp.Tests
{
    public class ReliefProjectsControllerTests
    {
        private readonly ApplicationDbContext _context;

        public ReliefProjectsControllerTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("ReliefProjectsTestDb").Options;

            _context = new ApplicationDbContext(options);
            SeedTestData.Populate(_context);
        }

        [Fact]
        public void Index_ReturnsListOfProjects()
        {
            var controller = new ReliefProjectsController(_context);
            var result = controller.Index().Result as ViewResult;
            var model = result.Model as IEnumerable<ReliefProject>;

            Assert.NotNull(result);
            Assert.Equal(2, model.Count());
        }
    }
}
