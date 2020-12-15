namespace GreenCap.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using GreenCap.Data.Common.Repositories;
    using GreenCap.Data.Models;
    using GreenCap.Services.Data.Common;
    using GreenCap.Services.Data.Contracts;
    using Microsoft.EntityFrameworkCore;

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

        public async Task<int> DeleteByIdAsync(int id, string userId)
        {
            var modelToDelete = await this.commentsDb.All().FirstOrDefaultAsync(x => x.Id == id);

            if (modelToDelete.UserId != userId)
            {
                throw new NullReferenceException(ExceptionMessages.YouCanDeleteOnlyYourOwnCommentsException);
            }

            if (modelToDelete == null)
            {
                throw new NullReferenceException(ExceptionMessages.CommentNotFound);
            }

            this.commentsDb.Delete(modelToDelete);
            await this.commentsDb.SaveChangesAsync();

            return modelToDelete.PostId;
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
