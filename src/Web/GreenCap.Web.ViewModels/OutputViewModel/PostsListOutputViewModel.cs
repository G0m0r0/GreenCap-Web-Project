namespace GreenCap.Web.ViewModels.OutputViewModel
{
    using System.Collections.Generic;

    public class PostsListOutputViewModel : PagingViewModel
    {
        public IEnumerable<PostOutputViewModel> Posts { get; set; }
    }
}
