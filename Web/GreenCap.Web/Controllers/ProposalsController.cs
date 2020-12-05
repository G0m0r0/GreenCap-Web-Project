namespace GreenCap.Web.Controllers
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using GreenCap.Services.Data.Contracts;
    using GreenCap.Web.ViewModels.InputViewModels;
    using GreenCap.Web.ViewModels.OutputViewModel;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;

    public class ProposalsController : BaseController
    {
        private readonly IProposalService proposalService;
        private readonly IWebHostEnvironment environment;

        public ProposalsController(IProposalService proposalService, IWebHostEnvironment environment)
        {
            this.proposalService = proposalService;
            this.environment = environment;
        }

        public IActionResult All(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int ItemsPerPage = 9;

            var viewModel = new ProposalsListOutputViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                EntitiesCount = this.proposalService.GetCount(),
                Proposals = this.proposalService.GetAll<ProposalOutputViewModel>(id, ItemsPerPage),
                AspAction = nameof(this.All),
            };

            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            return this.View();
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(ProposalViewModel proposal)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            // get id from cookie
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var pathImages = $"{this.environment.WebRootPath}/Images";

            try
            {
                await this.proposalService.CreateAsync(proposal, userId, pathImages);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(proposal);
            }

            return this.Redirect("All");
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await this.proposalService.GetByIdAsync<ProposalDetailsOutputViewModel>(id);
            return this.View(model);
        }

        [Authorize]
        public IActionResult Personal(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int ItemsPerPage = 9;
            var userdId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var viewModel = new ProposalsListOutputViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                EntitiesCount = this.proposalService.GetCountPersonal(userdId),
                Proposals = this.proposalService.GetAllPersonal<ProposalOutputViewModel>(id, ItemsPerPage, userdId),
                AspAction = nameof(this.Personal),
            };

            return this.View(viewModel);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.proposalService.DeleteByIdAsync(id, userId);

            return this.Redirect("All");
        }
    }
}
