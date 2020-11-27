namespace GreenCap.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GreenCap.Web.ViewModels.InputViewModels;
    using GreenCap.Web.ViewModels.OutputViewModel;

    public interface IPostservice : IBaseService
    {
        Task CreateAsync(PostInputViewModel model, string id);

        Task DeleteByIdAsync(int id, string userId);

        int GetCount();

        int GetCountPersonal(string id);

        int GetCountByCategory(string categoryName);
    }
}
