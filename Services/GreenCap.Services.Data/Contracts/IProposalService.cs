namespace GreenCap.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GreenCap.Web.ViewModels.InputViewModels;
    using GreenCap.Web.ViewModels.OutputViewModel;

    public interface IProposalService : IBaseService
    {
        Task CreateAsync(ProposalViewModel model, string id);

        // Task<IEnumerable<ProposalOutputViewModel>> GetAllAsync();
        Task<IEnumerable<ProposalOutputViewModel>> GetAllForSignedInUserAsync(string id);

        Task<ProposalOutputViewModel> GetByIdAsync(int id);

        int GetCount();

        Task DeleteByIdAsync(int id);
    }
}
