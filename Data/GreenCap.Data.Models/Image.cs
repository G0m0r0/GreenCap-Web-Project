namespace GreenCap.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using GreenCap.Data.Common.Models;

    public class Image : BaseDeletableModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public ApplicationUser User { get; set; }

        [ForeignKey(nameof(User))]
        public string AddedById { get; set; }

        public string Extension { get; set; }

        public Proposal Proposal { get; set; }

        [ForeignKey(nameof(Proposal))]
        public int ProposalId { get; set; }

        // The content of this image is in the file system
    }
}
