namespace GreenCap.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GreenCap.Data;
    using GreenCap.Data.Common.Repositories;
    using GreenCap.Data.Models;
    using GreenCap.Data.Models.Enums;
    using GreenCap.Data.Repositories;
    using GreenCap.Services.Data.Contracts;
    using GreenCap.Web.ViewModels.InputViewModels;

    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Xunit;

    public class PostServiceTest
    {
        private readonly IPostservice postService;

        private readonly EfDeletableEntityRepository<Post> postRepo;
        private readonly EfDeletableEntityRepository<ApplicationUser> userRepo;

        private readonly IDeletableRepository connection;

        public PostServiceTest()
        {
            var options = new DbContextOptionsBuilder<IDeletableRepository>()
             .UseInMemoryDatabase(databaseName: "TestDb").Options;
            this.connection = new IDeletableRepository(options);

            this.postRepo = new EfDeletableEntityRepository<Post>(this.connection);
            this.userRepo = new EfDeletableEntityRepository<ApplicationUser>(this.connection);

            this.postService = new PostService(this.postRepo, this.userRepo);
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

        [Fact]
        public async Task CreateMethodShouldCreateUser()
        {
            var list = new List<Post>();
            var mockRepo = new Mock<IDeletableEntityRepository<Post>>();
            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Post>())).Callback(
                (Post post) => list.Add(post));

            var listUser = new List<ApplicationUser>();
            var mockRepoUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockRepoUser.Setup(x => x.All()).Returns(listUser.AsQueryable());
            mockRepoUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback(
                (ApplicationUser user) => listUser.Add(user));

            var service = new PostService(mockRepo.Object, mockRepoUser.Object);

            var postModel = new PostInputViewModel
            {
                Category = Category.General,
                Description = "Test description",
                ProblemTitle = "Test title",
            };

            await service.CreateAsync(postModel, "1");

            Assert.Single(list);
        }
    }
}
