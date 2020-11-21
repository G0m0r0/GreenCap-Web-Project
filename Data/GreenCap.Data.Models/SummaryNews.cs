namespace GreenCap.Data.Models
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using GreenCap.Data.Common;
    using GreenCap.Data.Common.Models;

    public class SummaryNews : BaseDeletableModel<int>
    {
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

        public virtual News News { get; set; }

        [ForeignKey(nameof(News))]
        public int NewsId { get; set; }
    }
}
