namespace GreenCap.Web.ViewModels.InputViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using AutoMapper;
    using GreenCap.Data.Common;
    using GreenCap.Data.Models;
    using GreenCap.Services.Mapping;

    public class ProposalViewModel : IMapFrom<Proposal>, IHaveCustomMappings
    {
        public int Id { get; set; }

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

        public string Image { get; set; }

        public string CreatedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Proposal, ProposalViewModel>()
                .ForMember(x => x.Image, opt =>
                    opt.MapFrom(x => "/Images/Proposals/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));

            configuration.CreateMap<Proposal, ProposalViewModel>()
                .ForMember(x => x.CreatedOn, opt =>
                  opt.MapFrom(x => x.CreatedOn.ToLocalTime().ToString("dd / MMM / yyyy")));
        }
    }
}
