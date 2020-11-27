namespace GreenCap.Web.ViewModels.OutputViewModel
{
    using AutoMapper;
    using GreenCap.Data.Models;
    using GreenCap.Services.Mapping;

    public class PostCommentsOutputViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public string Content { get; set; }

        public string PostedOn { get; set; }

        public string CreatorName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Comment, PostCommentsOutputViewModel>()
               .ForMember(x => x.PostedOn, opt =>
                 opt.MapFrom(x => x.CreatedOn.ToLocalTime().ToString("dd / MMM / yyyy")))
               .ForMember(x => x.CreatorName, opt =>
                 opt.MapFrom(x => x.User.UserName));
        }
    }
}
