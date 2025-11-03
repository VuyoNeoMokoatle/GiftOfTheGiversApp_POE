using Xunit;
using GiftOfTheGiversApp.Controllers;
using GiftOfTheGiversApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using GiftOfTheGiversApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace GiftOfTheGiversApp.Tests
{
    public class DonationsControllerTests
    {
        private readonly ApplicationDbContext _context;

        public DonationsControllerTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("DonationsTestDb")
                .Options;

            _context = new ApplicationDbContext(options);
            SeedTestData.Populate(_context);
        }

        [Fact]
        public async Task Index_ReturnsDonationsList()
        {
            // Arrange
            var controller = new DonationsController(_context);

            // Act
            var result = await controller.Index() as ViewResult;
            var model = result?.Model as IEnumerable<Donation>;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(model);
            Assert.Equal(2, model.Count());
        }
    }

  
}
