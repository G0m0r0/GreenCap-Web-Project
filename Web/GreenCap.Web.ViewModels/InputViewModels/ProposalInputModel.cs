﻿namespace GreenCap.Web.ViewModels.InputViewModels
{
    using System.ComponentModel.DataAnnotations;

    using GreenCap.Data.Common;

    using Microsoft.AspNetCore.Http;

    public class ProposalInputModel
    {
        [Required]
        [MinLength(DataValidation.NameTitleMinLength)]
        [MaxLength(DataValidation.NameTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(DataValidation.Proposal.DescriptionMinLength)]
        [MaxLength(DataValidation.Proposal.DescriptionMaxLength)]
        [DataType(DataType.MultilineText)]
        [RegularExpression("[A-Z][^_]+", ErrorMessage = "Description should start with upper letter.")]
        public string Description { get; set; }

        [Required]
        [MinLength(DataValidation.Proposal.ShortDescriptionMinLength),]
        [MaxLength(DataValidation.Proposal.ShortDescriptionMaxLength)]
        [RegularExpression("[A-Z][^_]+", ErrorMessage = "Short description should start with upper letter.")]
        public string ShortDescription { get; set; }

        [Required]
        public IFormFile Image { get; set; }
    }
}
