namespace GreenCap.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GreenCap.Web.ViewModels.EditViewModel;
    using GreenCap.Web.ViewModels.InputViewModels;

    public interface IProposalService : IBaseService
    {
        IEnumerable<T> GetAllPersonal<T>(int page, int itemsPerPage, string id);

        Task CreateAsync(ProposalViewModel model, string userId, string imagepath);

        Task DeleteByIdAsync(int id, string userId);

        Task UpdateAsync(int id, ProposalEditViewModel input, string userId);

        int GetCount();

        int GetCountPersonal(string id);
    }
}
