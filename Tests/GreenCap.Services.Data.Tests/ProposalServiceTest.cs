namespace GreenCap.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Ganss.XSS;

    using GreenCap.Data;
    using GreenCap.Data.Models;
    using GreenCap.Data.Repositories;
    using GreenCap.Services.Data.Contracts;
    using GreenCap.Web.ViewModels.InputViewModels;
    using GreenCap.Web.ViewModels.OutputViewModel;

    using Microsoft.AspNetCore.Hosting.Internal;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;

    using Moq;

    using Xunit;

    public class ProposalServiceTest : IDisposable
    {
        private readonly IProposalService proposalService;

        private readonly EfDeletableEntityRepository<Proposal> proposalRepository;
        private readonly IDeletableRepository connection;

        private readonly HostingEnvironment environment;
        private readonly IHtmlSanitizer htmlSanitizer;

        private IFormFile file;
        private ProposalViewModel proposalInputModel;

        public ProposalServiceTest()
        {
            var options = new DbContextOptionsBuilder<IDeletableRepository>()
              .UseInMemoryDatabase(databaseName: "TestDb").Options;
            this.connection = new IDeletableRepository(options);

            this.proposalRepository = new EfDeletableEntityRepository<Proposal>(this.connection);

            this.environment = new HostingEnvironment();
            this.htmlSanitizer = new HtmlSanitizer();

            this.InitializeFields();

            this.proposalService = new ProposalService(this.proposalRepository);
        }

        public void Dispose()
        {
            this.connection.Database.EnsureDeleted();
            this.connection.Dispose();
        }

        [Fact]
        public async Task GetCountShouldReturnCorrectNumberUsingDbContext()
        {
            var options = new DbContextOptionsBuilder<IDeletableRepository>()
                .UseInMemoryDatabase(databaseName: "ProposalService").Options;
            using var dbContext = new IDeletableRepository(options);
            dbContext.Proposals.Add(new Proposal());
            dbContext.Proposals.Add(new Proposal());
            dbContext.Proposals.Add(new Proposal());
            await dbContext.SaveChangesAsync();

            using var repository = new EfDeletableEntityRepository<Proposal>(dbContext);
            var service = new ProposalService(repository);
            Assert.Equal(3, service.GetCount());
        }

        private void InitializeFields()
        {
            var fileMock = new Mock<IFormFile>();
            var content = "Fake File";
            var fileName = "test.pdf";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;
            fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
            fileMock.Setup(_ => _.FileName).Returns(fileName);
            fileMock.Setup(_ => _.Length).Returns(ms.Length);

            this.file = fileMock.Object;

            this.proposalInputModel = new ProposalViewModel
            {
                Title = "test title",
                Description = "Test desription",
                ShortDescription = "Test short description",
                Images = new List<IFormFile>() { this.file },
            };
        }
    }
}
