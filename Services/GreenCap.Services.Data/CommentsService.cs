namespace GreenCap.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;
    using GreenCap.Data.Common.Repositories;
    using GreenCap.Data.Models;
    using GreenCap.Services.Data.Contracts;

    public class CommentsService : ICommentsService
    {
        private readonly IDeletableEntityRepository<Comment> commentsDb;

        public CommentsService(IDeletableEntityRepository<Comment> commentsDb)
        {
            this.commentsDb = commentsDb;
        }

        public async Task CreateAsync(int postId, string userId, string content, int? parentId = null)
        {
            var comment = new Comment
            {
                Content = content,
                ParentId = parentId,
                PostId = postId,
                UserId = userId,
            };

            await this.commentsDb.AddAsync(comment);
            await this.commentsDb.SaveChangesAsync();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool IsInPostId(int commentId, int postId)
        {
            var commentPostId = this.commentsDb
                                .All().Where(x => x.Id == commentId)
                                .Select(x => x.PostId)
                                .FirstOrDefault();

            return commentPostId == postId;
        }
    }
}
