namespace GreenCap.Web.Controllers
{
    using System.Threading.Tasks;

    using GreenCap.Common;
    using GreenCap.Services;
    using GreenCap.Services.Data.Contracts;
    using GreenCap.Web.ViewModels.OutputViewModel;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class NewsController : BaseController
    {
        private readonly IPhysNewsScarperService newsService;
        private readonly INewsService newsServiceData;

        public NewsController(IPhysNewsScarperService newsService, INewsService newsServiceData)
        {
            this.newsService = newsService;
            this.newsServiceData = newsServiceData;
        }

        public async Task<IActionResult> All(int id = 1)
        {
            const int constPages = 3;
            if (id == 1)
            {
                await this.newsService.ImportNewsAsync(constPages);
            }

            if (id <= 0)
            {
                return this.NotFound();
            }

            const int ItemsPerPage = 9;

            var viewModel = new NewsListOutputViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                EntitiesCount = this.newsServiceData.GetCount(),
                NewsList = this.newsServiceData.GetAll<NewsOutputViewModel>(id, ItemsPerPage),
                AspAction = nameof(this.All),
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await this.newsServiceData.GetByIdAsync<NewsOutputViewModel>(id);

            return this.View(model);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Refresh()
        {
            return this.RedirectToAction(nameof(this.All));
        }
    }
}
