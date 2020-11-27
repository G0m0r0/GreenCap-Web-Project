namespace GreenCap.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using GreenCap.Services.Data.Contracts;
    using GreenCap.Web.ViewModels.InputViewModels;
    using GreenCap.Web.ViewModels.OutputViewModel;
    using Microsoft.AspNetCore.Mvc;

    public class ForumController : BaseController
    {
        private readonly IPostservice postService;

        public ForumController(IPostservice postService)
        {
            this.postService = postService;
        }

        public IActionResult Personal(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int ItemsPerPage = 6;
            var userdId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var viewModel = new PostsListOutputViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                EntitiesCount = this.postService.GetCountPersonal(userdId),
                Posts = this.postService.GetAllPersonal<PostOutputViewModel>(id, ItemsPerPage, userdId),
            };

            return this.View(viewModel);
        }

        [Route("Forum/Latest")]
        public IActionResult All(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int ItemsPerPage = 6;

            var viewModel = new PostsListOutputViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                EntitiesCount = this.postService.GetCount(),
                Posts = this.postService.GetAll<PostOutputViewModel>(id, ItemsPerPage),
            };

            return this.View(viewModel);
        }

        public IActionResult Categories(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int ItemsPerPage = 6;

            var viewModel = new PostsListOutputViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                EntitiesCount = this.postService.GetCount(),
                Posts = this.postService.GetAll<PostOutputViewModel>(id, ItemsPerPage),
            };

            return this.View(viewModel);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostInputViewModel proposal)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.postService.CreateAsync(proposal, this.User.FindFirstValue(ClaimTypes.NameIdentifier));

            return this.Redirect("Categories");
        }
    }
}
