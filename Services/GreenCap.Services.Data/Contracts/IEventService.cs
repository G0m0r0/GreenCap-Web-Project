namespace GreenCap.Services.Data.Contracts
{
    using System.Threading.Tasks;

    using GreenCap.Web.ViewModels.InputViewModels;

    public interface IEventService : IBaseService
    {
        Task CreateAsync(EventInputViewModel model, string userId);

        Task DeleteByIdAsync(int id, string userId);

        Task JoinEventAsync(int eventId, string userId);

        Task CancelEventAsync(int eventId, string userId);

        int GetCount();
    }
}
