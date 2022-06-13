namespace GreenCap.Services.Data.Tests
{
    using System;
    using System.Threading.Tasks;

    using GreenCap.Data;
    using GreenCap.Data.Models;
    using GreenCap.Data.Repositories;
    using GreenCap.Services.Data.Contracts;
    using GreenCap.Web.ViewModels.InputViewModels;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class EventServiceTest
    {
#pragma warning disable CS0169 // The field 'EventServiceTest.envirnoment' is never used
        private readonly IWebHost envirnoment;
#pragma warning restore CS0169 // The field 'EventServiceTest.envirnoment' is never used
        private readonly IEventService eventService;

        private readonly EfDeletableEntityRepository<Event> eventRepo;
        private readonly EfDeletableEntityRepository<ApplicationUser> userRepo;
#pragma warning disable CS0649 // Field 'EventServiceTest.eventHost' is never assigned to, and will always have its default value null
        private readonly EfDeletableEntityRepository<UserEventHosts> eventHost;
#pragma warning restore CS0649 // Field 'EventServiceTest.eventHost' is never assigned to, and will always have its default value null
#pragma warning disable CS0649 // Field 'EventServiceTest.eventSignedIn' is never assigned to, and will always have its default value null
        private readonly EfDeletableEntityRepository<UserEventSignedIn> eventSignedIn;
#pragma warning restore CS0649 // Field 'EventServiceTest.eventSignedIn' is never assigned to, and will always have its default value null

        private readonly IDeletableRepository connection;

        public EventServiceTest()
        {
            var options = new DbContextOptionsBuilder<IDeletableRepository>()
             .UseInMemoryDatabase(databaseName: "TestDb").Options;
            this.connection = new IDeletableRepository(options);

            this.eventRepo = new EfDeletableEntityRepository<Event>(this.connection);
            this.userRepo = new EfDeletableEntityRepository<ApplicationUser>(this.connection);

            this.eventService = new EventService(this.eventRepo, this.userRepo, this.eventHost, this.eventSignedIn);
        }

        [Fact]
        public async Task TestAddPostCount()
        {
            var postModel = new EventInputViewModel
            {
                Description = "Test description",
                Name = "Test title",
                ImagePath = "test image",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow,
            };

            await this.eventService.CreateAsync(postModel, "test id");
            var countPosts = await this.eventRepo.All().CountAsync();

            Assert.Equal(1, countPosts);
        }
    }
}
