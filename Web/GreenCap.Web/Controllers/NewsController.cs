namespace GreenCap.Web.Controllers
{
    using System.Threading.Tasks;

    using GreenCap.Services;
    using Microsoft.AspNetCore.Mvc;

    public class NewsController : Controller
    {
        private readonly IPhysNewsScarperService newsService;

        public NewsController(IPhysNewsScarperService newsService)
        {
            this.newsService = newsService;
        }

        public async Task<IActionResult> All()
        {
            const int constPages = 10;
            // await this.newsService.ImportNewsAsync(constPages);

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Refresh()
        {
            return this.Redirect("All");
        }
    }
}
