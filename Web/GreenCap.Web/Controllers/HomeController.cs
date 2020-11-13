namespace GreenCap.Web.Controllers
{
    using System.Diagnostics;

    using GreenCap.Services.Data;
    using GreenCap.Web.ViewModels;
    using GreenCap.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IHomeStatistics homeStatistics;

        // private readonly IMapper mapper;
        public HomeController(IHomeStatistics homeStatistics)
        {
            this.homeStatistics = homeStatistics;

            // this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var statisticsDto = this.homeStatistics.GetCounts();

            // var viewModel = this.mapper.Map<HomeViewModel>(statisticsDto); // if we dont use automapper we have to do it manually
            var viewModel = new HomeViewModel
            {
                TotalEvents = statisticsDto.TotalEvents,
                TotalPosts = statisticsDto.TotalPosts,
                TotalProposals = statisticsDto.TotalProposals,
                TotalUsers = statisticsDto.TotalUsers,
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
