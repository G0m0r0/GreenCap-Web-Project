namespace GreenCap.Web.ViewModels.OutputViewModel
{
    using System.Collections.Generic;

    public class EventsListOutputViewModel : PagingViewModel
    {
        public IEnumerable<EventOutputViewModel> Events { get; set; }
    }
}
