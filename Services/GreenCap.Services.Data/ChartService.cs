namespace GreenCap.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using GreenCap.Data.Common.Repositories;
    using GreenCap.Data.Models;
    using GreenCap.Services.Data.Contracts;
    using Microsoft.EntityFrameworkCore;

    public class ChartService : IChartService
    {
        private readonly IDeletableEntityRepository<Event> events;
        private readonly IDeletableEntityRepository<Proposal> proposals;
        private readonly IDeletableEntityRepository<ApplicationUser> users;
        private readonly IDeletableEntityRepository<Post> posts;
        private readonly IDeletableEntityRepository<News> news;

        public ChartService(
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

        public async Task<int[]> GetMonthsActivity()
        {
            var monthlyActivity = new int[12];

            for (int i = 0; i < 12; i++)
            {
                monthlyActivity[i] = await this.GetMonthActivity(i);
            }

            return monthlyActivity;
        }

        private async Task<int> GetMonthActivity(int i)
        {
            i++;
            var createdEventsPerMonth = await this.events
                    .AllAsNoTracking()
                    .Where(x => x.CreatedOn.Month == i && x.CreatedOn.Year == DateTime.UtcNow.Year)
                    .CountAsync();

            var createdPostsPerMonth = await this.posts
                .AllAsNoTracking()
                .Where(x => x.CreatedOn.Month == i && x.CreatedOn.Year == DateTime.UtcNow.Year)
                .CountAsync();

            var createdProposalsPerMonth = await this.proposals
                .AllAsNoTracking()
                .Where(x => x.CreatedOn.Month == i && x.CreatedOn.Year == DateTime.UtcNow.Year)
                .CountAsync();

            var createdNewsPerMonth = await this.news
                .AllAsNoTracking()
                .Where(x => x.CreatedOn.Month == i && x.CreatedOn.Year == DateTime.UtcNow.Year)
                .CountAsync();

            var registerUsersPerMonth = await this.users
                .AllAsNoTracking()
                .Where(x => x.CreatedOn.Month == i && x.CreatedOn.Year == DateTime.UtcNow.Year)
                .CountAsync();

            var monthActivitySum = createdEventsPerMonth + createdNewsPerMonth + createdPostsPerMonth + createdProposalsPerMonth + registerUsersPerMonth;

            return monthActivitySum;
        }
    }
}
