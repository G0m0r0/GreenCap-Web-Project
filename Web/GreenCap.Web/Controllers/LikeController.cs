namespace GreenCap.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using GreenCap.Services.Data.Contracts;
    using GreenCap.Web.ViewModels.InputViewModels;
    using GreenCap.Web.ViewModels.OutputViewModel;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("Api/[controller]")]
    public class LikeController : BaseController
    {
        private readonly ILikeService likeService;

        public LikeController(ILikeService likeService)
        {
            this.likeService = likeService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<PostVoteResponseModel>> Post(PostLikeInputViewModel input)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.likeService.SetLikeAsync(input.PostId, userId, input.IsPositive);

            var voteModel = new PostVoteResponseModel
            {
                Likes = this.likeService.GetLikes(input.PostId),
                Disslikes = this.likeService.GetDisslikes(input.PostId),
            };

            return voteModel;
        }
    }
}
