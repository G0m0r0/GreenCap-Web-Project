namespace GreenCap.Web.ViewModels.OutputViewModel
{
    using System.Linq;

    using AutoMapper;
    using GreenCap.Data.Models;
    using GreenCap.Services.Mapping;

    public class ProposalDetailsOutputViewModel : IMapFrom<Proposal>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string CreatedOn { get; set; }

        public string Image { get; set; }

        public string CreatedByName { get; set; }

        public string Description { get; set; }

        public string ModifiedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Proposal, ProposalDetailsOutputViewModel>()
                .ForMember(x => x.Image, opt =>
                    opt.MapFrom(x => "/Images/Proposals/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension))
                .ForMember(x => x.CreatedOn, opt =>
                  opt.MapFrom(x => x.CreatedOn.ToLocalTime().ToString("dd / MMM / yyyy")))
                .ForMember(x => x.CreatedByName, opt =>
                  opt.MapFrom(x => x.User.UserName))
                .ForMember(x => x.ModifiedOn, opt =>
                   opt.MapFrom(x => (x.ModifiedOn == null) ? "Never modified" : x.ModifiedOn.ToString()));
        }
    }
}
