namespace GreenCap.Web.ViewModels.OutputViewModel
{
    using System.Collections.Generic;

    public class NewsListOutputViewModel : PagingViewModel
    {
        public IEnumerable<NewsOutputViewModel> NewsList { get; set; }
    }
}
