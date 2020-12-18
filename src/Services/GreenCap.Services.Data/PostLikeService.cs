namespace GreenCap.Services.Data
{
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading.Tasks;

    using GreenCap.Data.Common.Repositories;
    using GreenCap.Data.Models;
    using GreenCap.Services.Data.Contracts;

    public class PostLikeService : ILikeService
    {
        private readonly IRepository<UserLike> likesDb;

        public PostLikeService(IRepository<UserLike> likesDb)
        {
            this.likesDb = likesDb;
        }

        public int GetDisslikes(int postId)
        {
            return this.likesDb
                .All()
                .Where(x => x.PostId == postId)
                .Where(x => !x.IsPositive)
                .Count();
        }

        public int GetLikes(int postId)
        {
            return this.likesDb
                .All()
                .Where(x => x.PostId == postId)
                .Where(x => x.IsPositive)
                .Count();
        }

        public async Task SetLikeAsync(int postId, string userId, bool isPositive)
        {
            var like = this.likesDb.All()
                .FirstOrDefault(x => x.PostId == postId && x.UserId == userId);

            if (like == null)
            {
                like = new UserLike
                {
                    PostId = postId,
                    UserId = userId,
                };

                await this.likesDb.AddAsync(like);
            }

            like.IsPositive = isPositive;
            await this.likesDb.SaveChangesAsync();
        }
    }
}
