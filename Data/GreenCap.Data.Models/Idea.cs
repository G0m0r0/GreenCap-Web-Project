namespace GreenCap.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using GreenCap.Data.Common;

    using GreenCap.Data.Common.Models;

    public class Idea : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(DataValidation.NameTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(DataValidation.Idea.ImagePathLength)]
        public string ImagePath { get; set; }

        [Required]
        [MaxLength(DataValidation.Idea.DescriptionLength)]
        public string Description { get; set; }

        [Required]
        [MaxLength(DataValidation.Idea.ShortLength)]
        public string ShortDescription { get; set; }

        public virtual ApplicationUser User { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
    }
}
