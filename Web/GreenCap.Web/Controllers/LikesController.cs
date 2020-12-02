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
    [Route("api/[controller]")]
    public class LikesController : BaseController
    {
        private readonly ILikeService likeService;

        public LikesController(ILikeService likeService)
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
                DissLikes = this.likeService.GetDisslikes(input.PostId),
                PostId = input.PostId,
            };

            return voteModel;
        }
    }
}
