namespace GreenCap.Services.Data
{
    using System.Linq;

    using GreenCap.Data.Common.Repositories;
    using GreenCap.Data.Models;
    using GreenCap.Services.Data.Contracts;
    using GreenCap.Services.Data.DTOs;

    public class HomeService : IHomeService
    {
        private readonly IDeletableEntityRepository<Event> events;
        private readonly IDeletableEntityRepository<Proposal> proposals;
        private readonly IDeletableEntityRepository<ApplicationUser> users;
        private readonly IDeletableEntityRepository<Post> posts;
        private readonly IDeletableEntityRepository<News> news;

        public HomeService(
            IDeletableEntityRepository<Event> events,
            IDeletableEntityRepository<Proposal> proposals,
            IDeletableEntityRepository<ApplicationUser> users,
            IDeletableEntityRepository<Post> posts,
            IDeletableEntityRepository<News> news)
        {
            this.events = events;
            this.proposals = proposals;
            this.users = users;
            this.posts = posts;
            this.news = news;
        }

        public HomeStatisticsDto GetCounts()
        {
            var data = new HomeStatisticsDto
            {
                EventsCount = this.events.All().Count(),
                PostsCount = this.posts.All().Count(),
                ProposalsCount = this.proposals.All().Count(),
                UsersCount = this.users.All().Count(),
                NewsCount = this.news.All().Count(),
            };

            return data;
        }
    }
}
