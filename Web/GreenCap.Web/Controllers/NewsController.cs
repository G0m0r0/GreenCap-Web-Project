namespace GreenCap.Web.Controllers
{
    using System.Threading.Tasks;

    using GreenCap.Services;
    using GreenCap.Services.Data.Contracts;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Mvc;

    public class NewsController : Controller
    {
        private readonly IPhysNewsScarperService newsService;
        private readonly INewsService newsServiceData;

        public NewsController(IPhysNewsScarperService newsService, INewsService newsServiceData)
        {
            this.newsService = newsService;
            this.newsServiceData = newsServiceData;
        }

        public async Task<IActionResult> All()
        {
            const int constPages = 5;

            // await this.newsService.ImportNewsAsync(constPages);
            var models = await this.newsServiceData.GetAllAsync();

            return this.View(models);
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await this.newsServiceData.GetByIdAsync(id);

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Refresh()
        {
            return this.Redirect("All");
        }
    }
}
