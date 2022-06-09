namespace GreenCap.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GreenCap.Common;
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

        public async Task<List<int>> GetMonthsActivity()
        {
            var monthlyActivity = new List<int>();

            for (int i = 1; i <= (DateTime.Now.Year - GlobalConstants.WebsiteCreationYear) * 12; i++)
            {
                monthlyActivity.Add(await this.GetMonthActivity(i));
            }

            return monthlyActivity;
        }

        private async Task<int> GetMonthActivity(int i)
        {
            int yearToLookFor = GlobalConstants.WebsiteCreationYear;

            if (i > 12)
            {
                i = i - (12 * (i / 12));
                yearToLookFor += i / 12;
            }

            var createdEventsPerMonth = await this.events
                    .AllAsNoTracking()
                    .Where(x => x.CreatedOn.Month == i && x.CreatedOn.Year == yearToLookFor)
                    .CountAsync();

            var createdPostsPerMonth = await this.posts
                .AllAsNoTracking()
                .Where(x => x.CreatedOn.Month == i && x.CreatedOn.Year == yearToLookFor)
                .CountAsync();

            var createdProposalsPerMonth = await this.proposals
                .AllAsNoTracking()
                .Where(x => x.CreatedOn.Month == i && x.CreatedOn.Year == yearToLookFor)
                .CountAsync();

            var createdNewsPerMonth = await this.news
                .AllAsNoTracking()
                .Where(x => x.CreatedOn.Month == i && x.CreatedOn.Year == yearToLookFor)
                .CountAsync();

            var registerUsersPerMonth = await this.users
                .AllAsNoTracking()
                .Where(x => x.CreatedOn.Month == i && x.CreatedOn.Year == yearToLookFor)
                .CountAsync();

            var monthActivitySum = createdEventsPerMonth + createdNewsPerMonth + createdPostsPerMonth + createdProposalsPerMonth + registerUsersPerMonth;

            return monthActivitySum;
        }
    }
}
