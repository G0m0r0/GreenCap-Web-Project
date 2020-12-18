namespace GreenCap.Services.Data.Contracts
{
    using System.Threading.Tasks;

    public interface INewsService : IBaseService
    {
        Task DeleteByIdAsync(int id);

        int GetCount();
    }
}
