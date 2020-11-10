namespace GreenCap.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using GreenCap.Data.Common;

    using GreenCap.Data.Common.Models;

    public class Proposal : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(DataValidation.NameTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        [MaxLength(DataValidation.Proposal.DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [MaxLength(DataValidation.Proposal.ShortDescriptionMaxLength)]
        public string ShortDescription { get; set; }

        public virtual ApplicationUser User { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
    }
}
