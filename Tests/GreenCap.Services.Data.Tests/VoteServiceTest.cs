﻿namespace GreenCap.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GreenCap.Data.Common.Repositories;
    using GreenCap.Data.Models;
    using Moq;
    using Xunit;

    public class VoteServiceTest
    {
        [Fact]
        public async Task WhenUserVotes2TimesOnly1VoteShouldBeCounted()
        {
            var list = new List<Vote>();
            var mockRepo = new Mock<IRepository<Vote>>();
            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Vote>())).Callback(
                (Vote vote) => list.Add(vote));
            var service = new VotesService(mockRepo.Object);

            await service.SetVoteAsync(1, "1", 1);
            await service.SetVoteAsync(1, "1", 5);
            await service.SetVoteAsync(1, "1", 5);
            await service.SetVoteAsync(1, "1", 5);
            await service.SetVoteAsync(1, "1", 5);

            Assert.Single(list);
            Assert.Equal(5, list.First().Value);
        }

        [Fact]
        public async Task When2UsersVoteForTheSameProposalTheAverageVoteShouldBeCorrect()
        {
            var list = new List<Vote>();
            var mockRepo = new Mock<IRepository<Vote>>();
            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Vote>())).Callback(
                (Vote vote) => list.Add(vote));
            var service = new VotesService(mockRepo.Object);

            await service.SetVoteAsync(2, "Niki", 5);
            await service.SetVoteAsync(2, "Pesho", 1);
            await service.SetVoteAsync(2, "Niki", 2);

            mockRepo.Verify(x => x.AddAsync(It.IsAny<Vote>()), Times.Exactly(2));

            Assert.Equal(2, list.Count);
            Assert.Equal(1.5, service.GetAverageVotes(2));
        }
    }
}
