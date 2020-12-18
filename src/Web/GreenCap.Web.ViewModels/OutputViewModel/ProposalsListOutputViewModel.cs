namespace GreenCap.Web.ViewModels.OutputViewModel
{
    using System.Collections.Generic;

    public class ProposalsListOutputViewModel : PagingViewModel
    {
        public IEnumerable<ProposalOutputViewModel> Proposals { get; set; }
    }
}
