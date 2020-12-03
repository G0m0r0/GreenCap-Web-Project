namespace GreenCap.Services.Data.Contracts
{
    using System.Threading.Tasks;

    public interface ICommentsService
    {
        Task CreateAsync(int postId, string userId, string content, int? parentId = null);

        bool IsInPostId(int commentId, int postId);

        Task<int> DeleteByIdAsync(int id, string userId);
    }
}
