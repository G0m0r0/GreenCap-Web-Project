namespace GreenCap.Web.ViewModels.OutputViewModel
{
    using System;
    using System.Linq;

    using AutoMapper;
    using GreenCap.Data.Models;
    using GreenCap.Services.Mapping;

    public class EventOutputViewModel : IMapFrom<Event>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string HostedByNames { get; set; }

        public int TotalPeople { get; set; }

        public int NeededPeople { get; set; }

        public string CreatedOn { get; set; }

        public string ImagePath { get; set; }

        public string CretedDaysAgo { get; set; }

        public string SignedInByNames { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Event, EventOutputViewModel>()
                .ForMember(x => x.CreatedOn, opt =>
                  opt.MapFrom(x => x.CreatedOn.ToLocalTime().ToString("dd / MMM / yyyy")))
                 .ForMember(x => x.HostedByNames, opt =>
                   opt.MapFrom(x => string.Join(", ", x.UserEventsHosts.Select(y => y.User.UserName.Split('@', StringSplitOptions.RemoveEmptyEntries)[0]).ToList())))
                .ForMember(x => x.StartDate, opt =>
                  opt.MapFrom(x => x.StartDate.ToLocalTime().ToString("dd / MMM / yyyy")))
                .ForMember(x => x.EndDate, opt =>
                  opt.MapFrom(x => x.EndDate.ToLocalTime().ToString("dd / MMM / yyyy")))
                .ForMember(x => x.CretedDaysAgo, opt =>
                  opt.MapFrom(x => (DateTime.Now.DayOfYear - x.CreatedOn.ToLocalTime().DayOfYear) == 0 ?
                  "created today " :
                  ("created " +
                  ((DateTime.Now.DayOfYear - x.CreatedOn.ToLocalTime().DayOfYear) == 1 ? "Yesterday" :
                  $"{DateTime.Now.DayOfYear - x.CreatedOn.ToLocalTime().DayOfYear} days ago"))))
                .ForMember(x => x.SignedInByNames, opt =>
                   opt.MapFrom(x => string.Join(", ", x.UserEventSignedIn.Select(y => y.User.UserName.Split('@', StringSplitOptions.RemoveEmptyEntries)[0]).ToList())))
                .ForMember(x => x.NeededPeople, opt =>
                  opt.MapFrom(x => x.TotalPeople - x.UserEventSignedIn.Count(x => x.Id == this.Id)));
        }
    }
}
