﻿namespace GreenCap.Web.ViewModels.OutputViewModel
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using Ganss.Xss;
    using GreenCap.Data.Models;
    using GreenCap.Services.Mapping;

    public class PostDetailsOutputViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string ProblemTitle { get; set; }

        public string Description { get; set; }

        public string SanitizedDescription => new HtmlSanitizer().Sanitize(this.Description);

        public string CreatorName { get; set; }

        public string PostedOn { get; set; }

        public string CategoryName { get; set; }

        public int Likes { get; set; }

        public int DissLikes { get; set; }

        public string UserEmail { get; set; }

        public ICollection<PostCommentsOutputViewModel> Comments { get; set; }

        public string CommentsCount { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Post, PostDetailsOutputViewModel>()
                .ForMember(x => x.PostedOn, opt =>
                  opt.MapFrom(x => x.CreatedOn.ToLocalTime().ToString("dd / MMM / yyyy")))
                .ForMember(x => x.CreatorName, opt =>
                  opt.MapFrom(x => x.User.UserName.Split('@', System.StringSplitOptions.RemoveEmptyEntries)[0]))
                .ForMember(x => x.CategoryName, opt =>
                  opt.MapFrom(x => x.Category.ToString()))
                .ForMember(x => x.Likes, opt =>
                  opt.MapFrom(x => x.UsersLikes/*.Where(x => x.IsPositive)*/.Count(x => x.IsPositive)))
                .ForMember(x => x.DissLikes, opt =>
                  opt.MapFrom(x => x.UsersLikes/*.Where(x => !x.IsPositive)*/.Count(x => !x.IsPositive)));
        }
    }
}
