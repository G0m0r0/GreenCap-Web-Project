namespace GreenCap.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GreenCap.Web.ViewModels.InputViewModels;
    using GreenCap.Web.ViewModels.OutputViewModel;

    public interface IProposalService
    {
        Task CreateAsync(ProposalInputViewModel model, string id);

        Task<IEnumerable<ProposalOutputViewModel>> GetAllAsync();

        Task<IEnumerable<ProposalOutputViewModel>> GetAllForSignedInUserAsync(string id);

        Task<ProposalOutputViewModel> GetByIdAsync(int id);

        Task DeleteByIdAsync(int id);
    }
}
