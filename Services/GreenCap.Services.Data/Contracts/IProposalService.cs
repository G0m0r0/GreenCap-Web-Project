namespace GreenCap.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GreenCap.Web.ViewModels.InputViewModels;
    using GreenCap.Web.ViewModels.OutputViewModel;

    public interface IProposalService : IBaseService
    {
        Task CreateAsync(ProposalViewModel model, string id);

        Task DeleteByIdAsync(int id);

        int GetCount();

        int GetCountPersonal(string id);
    }
}
