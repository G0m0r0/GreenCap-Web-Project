namespace GreenCap.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GreenCap.Web.ViewModels.InputViewModels;
    using GreenCap.Web.ViewModels.OutputViewModel;

    public interface IProposalService
    {
        Task CreateAsync(ProposalInputViewModel model, string id);

        IEnumerable<ProposalOutputViewModel> GetAll();

        ProposalOutputViewModel GetById(int id);

        int Delete(string id);
    }
}
