namespace GreenCap.Web.ViewModels.EditViewModel
{
    using System.ComponentModel.DataAnnotations;

    using GreenCap.Data.Common;
    using GreenCap.Data.Models;
    using GreenCap.Data.Models.Enums;
    using GreenCap.Services.Mapping;

    public class PostEditViewModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataValidation.NameTitleMinLength)]
        [MaxLength(DataValidation.NameTitleMaxLength)]
        [Display(Name = "Title name")]
        public string ProblemTitle { get; set; }

        [Required]
        [MinLength(DataValidation.Post.DescriptionMinLength)]
        [MaxLength(DataValidation.Post.DescriptionMaxLength)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public Category Category { get; set; }
    }
}
