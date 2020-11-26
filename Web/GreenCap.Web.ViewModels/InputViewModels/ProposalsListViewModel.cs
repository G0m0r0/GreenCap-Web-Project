namespace GreenCap.Web.ViewModels.InputViewModels
{
    using System.Collections.Generic;

    public class ProposalsListViewModel : PagingViewModel
    {
        public IEnumerable<ProposalViewModel> Proposals { get; set; }
    }
}
