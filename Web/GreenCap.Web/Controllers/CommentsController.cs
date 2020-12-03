namespace GreenCap.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using GreenCap.Services.Data.Contracts;
    using GreenCap.Web.ViewModels.InputViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http.Extensions;
    using Microsoft.AspNetCore.Mvc;

    public class CommentsController : Controller
    {
        private readonly ICommentsService commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            this.commentsService = commentsService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CommentInputModel model)
        {
            var parentId = model.ParentId == 0 ? (int?)null : model.ParentId;

            if (parentId.HasValue)
            {
                if (!this.commentsService.IsInPostId(parentId.Value, model.PostId))
                {
                    return this.BadRequest();
                }
            }

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await this.commentsService.CreateAsync(model.PostId, userId, model.Content, parentId);

            return this.RedirectToAction("Details", "Forum", new { id = model.PostId });
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var postId = await this.commentsService.DeleteByIdAsync(id, userId);

            string url = this.Request.GetDisplayUrl();

            return this.RedirectToAction("Details", "Forum", new { id = postId });
        }
    }
}
