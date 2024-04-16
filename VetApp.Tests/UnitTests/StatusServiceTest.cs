namespace VetApp.Tests.UnitTests
{
    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;
    using VetApp.Data;
    using VetApp.Data.Models;
    using VetApp.Services;
    using VetApp.Services.Interfaces;
    using VetApp.Web.ViewModels.Status;

    [TestFixture]
    public class StatusServiceTest
    {
        private IEnumerable<Status> statuses;
        private VetAppDbContext context;

        [OneTimeSetUp]
        public void SetUp()
        {
            statuses = new List<Status>()
            {
                new(){Id = 2,Name = "Done",},
                new(){Id = 3,Name = "Hospital",},
                new(){Id = 4,Name = "New", },
            };

            var options = new DbContextOptionsBuilder<VetAppDbContext>()
                .UseInMemoryDatabase(databaseName: "VetAppInMemoryDb")
                .Options;

            context = new VetAppDbContext(options);
            context.AddRange(statuses);
            context.SaveChanges();
        }

        [Test]
        public async Task GetAllStatuses_ShouldReturnAllStatuses()
        {
            IStatusService statusService = new StatusService(context);
            IEnumerable<StatusViewModel> expected =
                await statusService.AllStatusesAsync();

            var actual = context.Statuses.ToList();

            Assert.That(expected.Count(), Is.EqualTo(actual.Count));

            for (int i = 0; i < expected.Count(); i++)
            {
                Assert.That(actual.ElementAt(i).Id, Is.EqualTo(expected.ElementAt(i).Id));
                Assert.That(actual.ElementAt(i).Name, Is.EqualTo(expected.ElementAt(i).Name));
            }
        }
    }
}
