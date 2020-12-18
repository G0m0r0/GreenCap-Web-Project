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

        [Required]
        [MaxLength(DataValidation.News.PostedOnMaxLength)]
        public string PostedOn { get; set; }

        [Required]
        [MaxLength(DataValidation.News.SummaryMaxLength)]
        public string Summary { get; set; }

        [Required]
        [MaxLength(DataValidation.UrlPathMaxLength)]
        public string OriginalUrl { get; set; }

        [MaxLength(DataValidation.UrlPathMaxLength)]
        public string ImageSmallUrl { get; set; }

        public virtual CategoryNews Category { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
    }
}
