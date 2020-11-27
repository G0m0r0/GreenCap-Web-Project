namespace GreenCap.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GreenCap.Web.ViewModels.InputViewModels;
    using GreenCap.Web.ViewModels.OutputViewModel;

    public interface IProposalService : IBaseService
    {
        Task CreateAsync(ProposalViewModel model, string id, string imagepath);

        Task DeleteByIdAsync(int id, string userId);

        int GetCount();

        int GetCountPersonal(string id);
    }
}
