namespace GreenCap.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using GreenCap.Data.Common;
    using GreenCap.Data.Common.Models;

    public class News : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(DataValidation.NameTitleMaxLength)]
        public string Title { get; set; }

        [MaxLength(DataValidation.UrlPathMaxLength)]
        public string ImageUrl { get; set; }

        [MaxLength(DataValidation.News.CreditMaxLength)]
        public string Credit { get; set; }

        [Required]
        [MaxLength(DataValidation.News.DescriptionMaxLength)]
        public string Description { get; set; }

        public virtual SummaryNews SummaryNews { get; set; }

        [ForeignKey(nameof(SummaryNews))]
        public int SummaryNewsId { get; set; }
    }
}
