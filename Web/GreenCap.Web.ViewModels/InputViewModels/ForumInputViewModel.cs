namespace GreenCap.Web.ViewModels.InputViewModels
{
    using System.ComponentModel.DataAnnotations;

    using GreenCap.Data.Common;
    using GreenCap.Data.Models.Enums;

    public class ForumInputViewModel
    {
        [Required]
        [MinLength(DataValidation.NameTitleMinLength)]
        [MaxLength(DataValidation.NameTitleMaxLength)]
        [Display(Name = "Title name")]
        public string ProblemTitle { get; set; }

        [Required]
        [MinLength(DataValidation.Post.DescriptionMinLength)]
        [MaxLength(DataValidation.Post.DescriptionMaxLength)]
        [RegularExpression("[A-Z][^_]+", ErrorMessage = "Description should start with upper letter.")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public Category Category { get; set; }
    }
}
