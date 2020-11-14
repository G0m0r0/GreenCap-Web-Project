namespace GreenCap.Services.Data
{
    using System.Linq;

    using GreenCap.Data.Common.Repositories;
    using GreenCap.Data.Models;
    using GreenCap.Services.Data.Contracts;
    using GreenCap.Services.Data.DTOs;

    public class HomeStatistics : IHomeStatistics
    {
        private readonly IDeletableEntityRepository<Event> events;
        private readonly IDeletableEntityRepository<Proposal> proposals;
        private readonly IDeletableEntityRepository<ApplicationUser> users;
        private readonly IDeletableEntityRepository<Post> posts;

        public HomeStatistics(
            IDeletableEntityRepository<Event> events,
            IDeletableEntityRepository<Proposal> proposals,
            IDeletableEntityRepository<ApplicationUser> users,
            IDeletableEntityRepository<Post> posts)
        {
            this.events = events;
            this.proposals = proposals;
            this.users = users;
            this.posts = posts;
        }

        public HomeStatisticsDTO GetCounts()
        {
            var data = new HomeStatisticsDTO
            {
                TotalEvents = this.events.All().Count(),
                TotalPosts = this.posts.All().Count(),
                TotalProposals = this.proposals.All().Count(),
                TotalUsers = this.users.All().Count(),
            };

            return data;
        }
    }
}
