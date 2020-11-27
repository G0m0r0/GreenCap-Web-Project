namespace GreenCap.Web.ViewModels.OutputViewModel
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using GreenCap.Data.Models;
    using GreenCap.Services.Mapping;

    public class PostOutputViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public string ProblemTitle { get; set; }

        public string Description { get; set; }

        public string CreatorName { get; set; }

        public string PostedOn { get; set; }

        public string CategoryName { get; set; }

        public int Likes { get; set; }

        public int DissLikes { get; set; }

        public ICollection<PostCommentsOutputViewModel> Comments { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Post, PostOutputViewModel>()
                .ForMember(x => x.PostedOn, opt =>
                  opt.MapFrom(x => x.CreatedOn.ToLocalTime().ToString("dd / MMM / yyyy")))
                .ForMember(x => x.CategoryName, opt =>
                  opt.MapFrom(x => x.Category.ToString()))
                .ForMember(x => x.Likes, opt =>
                  opt.MapFrom(x => x.UsersLikes.Where(x => x.IsPositive).Count()))
                .ForMember(x => x.DissLikes, opt =>
                  opt.MapFrom(x => x.UsersLikes.Where(x => !x.IsPositive).Count()));
        }
    }
}
