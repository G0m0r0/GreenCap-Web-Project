namespace GreenCap.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GreenCap.Web.ViewModels.InputViewModels;
    using GreenCap.Web.ViewModels.OutputViewModel;

    public interface IPostservice
    {
        Task CreateAsync(PostInputViewModel model, string id);

        Task<IEnumerable<PostOutputViewModel>> GetAllAsync();

        Task<IEnumerable<PostOutputViewModel>> GetAllForSignedInUserAsync(string id);

        Task<PostOutputViewModel> GetByIdAsync(int id);

        Task DeleteByIdAsync(int id);
    }
}
