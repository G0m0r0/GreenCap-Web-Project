namespace GreenCap.Data.Models
{
    using GreenCap.Data.Common.Models;

    public class Vote : BaseModel<int>
    {
        public int ProposalId { get; set; }

        public virtual Proposal Proposal { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public byte Value { get; set; }
    }
}
