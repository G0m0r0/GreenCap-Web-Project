namespace GreenCap.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GreenCap.Web.ViewModels.OutputViewModel;

    public interface INewsService
    {
        Task<IEnumerable<NewsOutputViewModel>> GetAllAsync();

        Task<NewsOutputViewModel> GetByIdAsync(int id);

        Task DeleteByIdAsync(int id);
    }
}
