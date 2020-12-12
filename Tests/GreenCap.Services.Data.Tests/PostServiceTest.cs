namespace GreenCap.Services.Data.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Ganss.XSS;

    using GreenCap.Data;
    using GreenCap.Data.Common.Repositories;
    using GreenCap.Data.Models;
    using GreenCap.Data.Models.Enums;
    using GreenCap.Data.Repositories;
    using GreenCap.Services.Data.Contracts;
    using GreenCap.Web.ViewModels.InputViewModels;
    using GreenCap.Web.ViewModels.OutputViewModel;

    using Microsoft.EntityFrameworkCore;

    using Xunit;
    public class PostServiceTest : IDisposable
    {
        private readonly IPostservice postService;

        private EfDeletableEntityRepository<Post> postRepo;
        private EfDeletableEntityRepository<ApplicationUser> userRepo;

        private IDeletableRepository connection;
        private IHtmlSanitizer htmlSanitizer;

        public PostServiceTest()
        {
            var options = new DbContextOptionsBuilder<IDeletableRepository>()
             .UseInMemoryDatabase(databaseName: "TestDb").Options;
            this.connection = new IDeletableRepository(options);

            this.postRepo = new EfDeletableEntityRepository<Post>(this.connection);
            this.userRepo = new EfDeletableEntityRepository<ApplicationUser>(this.connection);

            this.htmlSanitizer = new HtmlSanitizer();

            this.htmlSanitizer = new HtmlSanitizer();

            this.postService = new PostService(this.postRepo, this.userRepo);
        }

        public void Dispose()
        {
            this.connection.Database.EnsureDeleted();
            this.connection.Dispose();
        }

        [Fact]
        public async Task TestAddPostCount()
        {
            var postModel = new PostInputViewModel
            {
                Category = Category.General,
                Description = "Test description",
                ProblemTitle = "Test title",
            };

            await this.postService.CreateAsync(postModel, "test id");
            var countPosts = await this.postRepo.All().CountAsync();

            Assert.Equal(1, countPosts);
        }

        [Fact]
        public async Task TestIfCreatedPostPropertiesAreCorrect()
        {
            var postModel = new PostInputViewModel
            {
                Category = Category.General,
                Description = "Test description",
                ProblemTitle = "Test title",
            };

            await this.postService.CreateAsync(postModel, "test id");
            var title = await this.postRepo.All().FirstOrDefaultAsync();

            Assert.Equal("Test title", title.ProblemTitle);
            Assert.Equal("Test description", title.Description);
            Assert.Equal(Category.General, title.Category);
        }

        [Fact]
        public async Task TestGetAllEntities()
        {
            // var postModel = new PostInputViewModel
            // {
            //     Category = Category.General,
            //     Description = "Test description",
            //     ProblemTitle = "Test title",
            // };
            //
            // await this.postService.CreateAsync(postModel, "test id");
            //
            // var models = this.postService.GetAll<PostOutputViewModel>(1, 6);
            //
            // Assert.Single(models);
        }

        [Fact]
        public async Task TestGetCountMethod()
        {
            var postModel = new PostInputViewModel
            {
                Category = Category.General,
                Description = "Test description",
                ProblemTitle = "Test title",
            };

            await this.postService.CreateAsync(postModel, "test id");
            var countPosts = this.postService.GetCount();

            Assert.Equal(1, countPosts);
        }

        [Fact]
        public async Task TestGetCountCategoryMethod()
        {
            var postModel = new PostInputViewModel
            {
                Category = Category.General,
                Description = "Test description",
                ProblemTitle = "Test title",
            };

            await this.postService.CreateAsync(postModel, "test id");
            var countPosts = this.postService.GetCountByCategory("General");

            Assert.Equal(1, countPosts);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("   ")]
        [InlineData("bla bla")]
        public async Task TestGetCountByCategoryExeptionCategoryNameDoesNotExist(string value)
        {
            var postModel = new PostInputViewModel
            {
                Category = Category.General,
                Description = "Test description",
                ProblemTitle = "Test title",
            };

            await this.postService.CreateAsync(postModel, "test id");

            Assert.Throws<NullReferenceException>(
                () => this.postService
                        .GetCountByCategory(value));
        }

        [Fact]
        public async Task TestGetCountPersonalExeptionUserDoesNotExist()
        {
            var postModel = new PostInputViewModel
            {
                Category = Category.General,
                Description = "Test description",
                ProblemTitle = "Test title",
            };

            await this.postService.CreateAsync(postModel, "test id");

            Assert.Throws<NullReferenceException>(
                () => this.postService.GetCountPersonal("not valid"));
        }

    }
}
