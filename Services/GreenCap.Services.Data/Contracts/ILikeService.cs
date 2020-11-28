namespace GreenCap.Services.Data.Contracts
{
    using System.Threading.Tasks;

    public interface ILikeService
    {
        Task SetLikeAsync(int postId, string userId, bool isPositive);

        int GetLikes(int postId);

        int GetDisslikes(int postId);
    }
}
