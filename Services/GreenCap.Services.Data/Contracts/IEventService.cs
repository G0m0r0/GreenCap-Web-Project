namespace GreenCap.Services.Data.Contracts
{
    using System.Threading.Tasks;

    public interface IEventService : IBaseService
    {
        Task DeleteByIdAsync(int id);

        int GetCount();
    }
}
