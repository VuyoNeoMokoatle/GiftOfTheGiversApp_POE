using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.IO;

namespace GiftOfTheGiversApp.Tests
{
    public class ApiIntegrationTests : IClassFixture<TestWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public ApiIntegrationTests(TestWebApplicationFactory<Program> factory)
        {
            // Set working directory to main app output
            var mainAppOutput = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "GiftOfTheGiversApp", "bin", "Debug", "net9.0");
            if (Directory.Exists(mainAppOutput))
                Directory.SetCurrentDirectory(mainAppOutput);

            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Get_ReliefProjects_ReturnsSuccess()
        {
            // Arrange
            var requestUri = "/api/reliefprojects";

            // Act
            var response = await _client.GetAsync(requestUri);

            // Assert
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            Assert.False(string.IsNullOrEmpty(content));
        }
    }
}


