namespace GreenCap.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using GreenCap.Data.Common.Repositories;
    using GreenCap.Data.Models;
    using GreenCap.Services.Data.Contracts;

    public class VotesService : IVotesService
    {
        private readonly IRepository<Vote> votesRepository;

        public VotesService(IRepository<Vote> votesRepository)
        {
            this.votesRepository = votesRepository;
        }

        public double GetAverageVotes(int proposalId)
        {
            return this.votesRepository.All()
                .Where(x => x.ProposalId == proposalId)
                .Average(x => x.Value);
        }

        public async Task SetVoteAsync(int proposalId, string userId, byte value)
        {
            var vote = this.votesRepository.All()
                .FirstOrDefault(x => x.ProposalId == proposalId && x.UserId == userId);

            if (vote == null)
            {
                vote = new Vote
                {
                    ProposalId = proposalId,
                    UserId = userId,
                };

                await this.votesRepository.AddAsync(vote);
            }

            vote.Value = value;
            await this.votesRepository.SaveChangesAsync();
        }
    }
}
