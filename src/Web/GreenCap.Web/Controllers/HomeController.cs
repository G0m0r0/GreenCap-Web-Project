namespace GreenCap.Web.Controllers
{
    using System.Diagnostics;

    using GreenCap.Services.Data.Contracts;
    using GreenCap.Web.ViewModels;
    using GreenCap.Web.ViewModels.OutputViewModel;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IHomeService homeStatistics;

        public HomeController(IHomeService homeStatistics)
        {
            this.homeStatistics = homeStatistics;
        }

        public IActionResult Index()
        {
            var statisticsDto = this.homeStatistics.GetCounts();

            var viewModel = new HomeStatisticsOutputViewModel
            {
                EventsCount = statisticsDto.EventsCount,
                PostsCount = statisticsDto.PostsCount,
                ProposalsCount = statisticsDto.ProposalsCount,
                UsersCount = statisticsDto.UsersCount,
                NewsCount = statisticsDto.NewsCount,
            };

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
