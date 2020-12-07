namespace GreenCap.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GreenCap.Web.ViewModels.EditViewModel;
    using GreenCap.Web.ViewModels.InputViewModels;

    public interface IPostservice : IBaseService
    {
        IEnumerable<T> GetAllPersonal<T>(int page, int itemsPerPage, string id);

        Task CreateAsync(PostInputViewModel model, string id);

        Task DeleteByIdAsync(int id, string userId);

        Task UpdateAsync(int id, PostEditViewModel input);

        int GetCount();

        int GetCountPersonal(string id);

        int GetCountByCategory(string categoryName);
    }
}
