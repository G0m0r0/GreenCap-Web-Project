namespace GreenCap.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using GreenCap.Data.Common;
    using GreenCap.Data.Common.Models;

    public class CategoryNews : BaseDeletableModel<int>
    {
        public CategoryNews()
        {
            this.SummaryNews = new HashSet<SummaryNews>();
        }

        [Required]
        [MaxLength(DataValidation.NameTitleMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<SummaryNews> SummaryNews { get; set; }
    }
}
