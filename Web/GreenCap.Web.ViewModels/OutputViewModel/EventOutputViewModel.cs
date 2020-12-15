namespace GreenCap.Web.ViewModels.OutputViewModel
{
    using AutoMapper;
    using GreenCap.Data.Models;
    using GreenCap.Services.Mapping;
    using System;

    public class EventOutputViewModel : IMapFrom<Event>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string HostedByName { get; set; }

        public int TotalPeople { get; set; }

        public int NeededPeople { get; set; }

        public string CreatedOn { get; set; }

        public string ImagePath { get; set; }

        public string CretedDaysAgo { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Event, EventOutputViewModel>()
                .ForMember(x => x.CreatedOn, opt =>
                  opt.MapFrom(x => x.CreatedOn.ToLocalTime().ToString("dd / MMM / yyyy")))
                .ForMember(x => x.HostedByName, opt =>
                  opt.MapFrom(x => x.HostedBy.UserName.Split('@', System.StringSplitOptions.RemoveEmptyEntries)[0]))
                .ForMember(x => x.StartDate, opt =>
                  opt.MapFrom(x => x.StartDate.ToLocalTime().ToString("dd / MMM / yyyy")))
                .ForMember(x => x.EndDate, opt =>
                  opt.MapFrom(x => x.EndDate.ToLocalTime().ToString("dd / MMM / yyyy")))
                .ForMember(x => x.CreatedOn, opt =>
                  opt.MapFrom(x => (DateTime.Now.DayOfYear - x.CreatedOn.ToLocalTime().DayOfYear) == 0 ?
                  "today" :
                  ("created on" + (DateTime.Now.DayOfYear - x.CreatedOn.ToLocalTime().DayOfYear) + "days ago")));
        }
    }
}
