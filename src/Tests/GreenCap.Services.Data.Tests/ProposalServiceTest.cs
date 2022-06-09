namespace GreenCap.Services.Data.Tests
{
    using GreenCap.Data;
    using GreenCap.Data.Models;
    using GreenCap.Data.Repositories;
    using GreenCap.Services.Data.Contracts;
    using Microsoft.EntityFrameworkCore;

    public class ProposalServiceTest
    {
        private readonly IProposalService proposalService;

        private readonly EfDeletableEntityRepository<Proposal> proposalRepo;

        private readonly IDeletableRepository connection;

        public ProposalServiceTest()
        {
            var options = new DbContextOptionsBuilder<IDeletableRepository>()
             .UseInMemoryDatabase(databaseName: "TestDb").Options;
            this.connection = new IDeletableRepository(options);

            this.proposalRepo = new EfDeletableEntityRepository<Proposal>(this.connection);

            this.proposalService = new ProposalService(this.proposalRepo);
        }
    }
}
