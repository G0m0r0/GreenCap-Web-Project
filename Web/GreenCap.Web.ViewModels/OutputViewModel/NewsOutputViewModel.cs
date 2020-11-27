namespace GreenCap.Web.ViewModels.OutputViewModel
{
    using AutoMapper;
    using GreenCap.Data.Models;
    using GreenCap.Services.Mapping;

    public class NewsOutputViewModel : IMapFrom<News>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Credit { get; set; }

        public string Description { get; set; }

        public string PostedOn { get; set; }

        public string Summary { get; set; }

        public string OriginalUrl { get; set; }

        public string ImageSmallUrl { get; set; }

        public string CategoryName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<News, NewsOutputViewModel>()
                .ForMember(x => x.PostedOn, opt =>
                  opt.MapFrom(x => x.CreatedOn.ToLocalTime().ToString("dd / MMM / yyyy")))
                .ForMember(x => x.CategoryName, opt =>
                  opt.MapFrom(x => x.Category.Name))
                .ForMember(x => x.Credit, opt =>
                  opt.MapFrom(x => x.Credit.StartsWith("Credit:") ? x.Credit : "Credit: Admin"));
        }
    }
}
