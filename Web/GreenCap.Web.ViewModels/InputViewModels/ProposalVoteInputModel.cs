namespace GreenCap.Web.ViewModels.InputViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class ProposalVoteInputModel
    {
        public int ProposalId { get; set; }

        [Range(1, 5)]
        public byte Value { get; set; }
    }
}
