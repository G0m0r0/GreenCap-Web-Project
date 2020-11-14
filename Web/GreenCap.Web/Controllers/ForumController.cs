namespace GreenCap.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using GreenCap.Services.Data.Contracts;
    using GreenCap.Web.ViewModels.InputViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class ForumController : BaseController
    {
        private readonly IPostservice postService;

        public ForumController(IPostservice postService)
        {
            this.postService = postService;
        }

        public async Task<IActionResult> Personal()
        {
            var forumModel = await this.postService.GetAllForSignedInUserAsync(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            return this.View(forumModel);
        }

        public async Task<IActionResult> Latest()
        {
            var postModel = await this.postService.GetAllAsync();
            return this.View(postModel);
        }

        public async Task<IActionResult> Categories()
        {
            var postModel = await this.postService.GetAllAsync();
            return this.View(postModel);
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
