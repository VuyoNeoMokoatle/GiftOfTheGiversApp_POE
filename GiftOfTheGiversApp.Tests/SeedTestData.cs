using GiftOfTheGiversApp.Data;
using GiftOfTheGiversApp.Models;
using System;

namespace GiftOfTheGiversApp.Tests
{
    public static class SeedTestData
    {
        public static void Populate(ApplicationDbContext context)
        {
            // Clear existing data before seeding
            context.ReliefProjects.RemoveRange(context.ReliefProjects);
            context.Donations.RemoveRange(context.Donations);
            context.SaveChanges();

            // ✅ Relief projects now match your model fields
            context.ReliefProjects.AddRange(
                new ReliefProject
                {
                    ProjectId = 1,
                    ProjectName = "Water Aid",
                    Location = "Cape Town",
                    StartDate = DateTime.UtcNow.AddDays(-30),
                    EndDate = null
                },
                new ReliefProject
                {
                    ProjectId = 2,
                    ProjectName = "Food Relief",
                    Location = "Johannesburg",
                    StartDate = DateTime.UtcNow.AddDays(-15),
                    EndDate = null
                }
            );

            // ✅ Donations now match your Donation.cs model
            context.Donations.AddRange(
                new Donation
                {
                    Id = 1,
                    DonorName = "John Doe",
                    DonationType = "Money",
                    Amount = 500,
                    Date = DateTime.UtcNow,
                    ProjectId = 1
                },
                new Donation
                {
                    Id = 2,
                    DonorName = "Jane Doe",
                    DonationType = "Food",
                    Amount = 300,
                    Date = DateTime.UtcNow,
                    ProjectId = 2
                }
            );

            context.SaveChanges();
        }
    }
}
