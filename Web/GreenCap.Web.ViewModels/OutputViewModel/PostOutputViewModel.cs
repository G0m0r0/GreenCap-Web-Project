namespace GreenCap.Web.ViewModels.OutputViewModel
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text.RegularExpressions;

    using AutoMapper;
    using GreenCap.Data.Common;
    using GreenCap.Data.Models;
    using GreenCap.Services.Mapping;

    public class PostOutputViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string ProblemTitle { get; set; }

        public string Description { get; set; }

        public string ShortDescription
        {
            get
            {
                var description = WebUtility.HtmlDecode(Regex.Replace(this.Description, @"<[^>]+>", string.Empty));

                return description.Length > DataValidation.Post.ShortDescriptionMaxLength ?
                       description
                       .Substring(DataValidation.Post.ShortDescriptionMinLength, DataValidation.Post.ShortDescriptionMaxLength) + "..."
                       : description;
            }
        }

        public string CreatorName { get; set; }

        public string PostedOn { get; set; }

        public string CategoryName { get; set; }

        public int Likes { get; set; }

        public int DissLikes { get; set; }

        public string CommentsCount { get; set; }

        public IEnumerable<PostCommentsOutputViewModel> Comments { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Post, PostOutputViewModel>()
                .ForMember(x => x.PostedOn, opt =>
                  opt.MapFrom(x => x.CreatedOn.ToLocalTime().ToString("dd / MMM / yyyy")))
                .ForMember(x => x.CreatorName, opt =>
                  opt.MapFrom(x => x.User.UserName.Split('@', System.StringSplitOptions.RemoveEmptyEntries)[0]))
                .ForMember(x => x.CategoryName, opt =>
                  opt.MapFrom(x => x.Category.ToString()))
                .ForMember(x => x.Likes, opt =>
                  opt.MapFrom(x => x.UsersLikes.Where(x => x.IsPositive).Count()))
                .ForMember(x => x.DissLikes, opt =>
                  opt.MapFrom(x => x.UsersLikes.Where(x => !x.IsPositive).Count()));
        }
    }
}
