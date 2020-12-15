namespace GreenCap.Services.Data.Contracts
{
    using System.Threading.Tasks;

    using GreenCap.Web.ViewModels.InputViewModels;

    public interface IEventService : IBaseService
    {
        Task CreateAsync(EventInputViewModel model, string userId);

        Task DeleteByIdAsync(int id, string userId);

        int GetCount();
    }
}
