namespace GreenCap.Web.ViewModels.OutputViewModel
{
    using AutoMapper;
    using Ganss.Xss;
    using GreenCap.Data.Models;
    using GreenCap.Services.Mapping;

    public class PostCommentsOutputViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public string Content { get; set; }

        public string PostedOn { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public string CreatorName { get; set; }

        public string UserEmail { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Comment, PostCommentsOutputViewModel>()
               .ForMember(x => x.PostedOn, opt =>
                 opt.MapFrom(x => x.CreatedOn.ToLocalTime().ToString("dd / MMM / yyyy")))
               .ForMember(x => x.CreatorName, opt =>
                  opt.MapFrom(x => x.User.UserName.Split('@', System.StringSplitOptions.RemoveEmptyEntries)[0]));
        }
    }
}
