namespace GreenCap.Web.Controllers
{
    using System;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    using GreenCap.Common;
    using GreenCap.Services.Data.Contracts;
    using GreenCap.Services.Messaging;
    using GreenCap.Web.ViewModels.EditViewModel;
    using GreenCap.Web.ViewModels.InputViewModels;
    using GreenCap.Web.ViewModels.OutputViewModel;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;

    public class ProposalsController : BaseController
    {
        private readonly IProposalService proposalService;
        private readonly IWebHostEnvironment environment;
        private readonly IEmailSender emailSender;

        public ProposalsController(IProposalService proposalService, IWebHostEnvironment environment, IEmailSender emailSender)
        {
            this.proposalService = proposalService;
            this.environment = environment;
            this.emailSender = emailSender;
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
        public async Task<IActionResult> Edit(int id)
        {
            var inputModel = await this.proposalService.GetByIdAsync<ProposalEditViewModel>(id);

            return this.View(inputModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(int id, ProposalEditViewModel proposal)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await this.proposalService.UpdateAsync(id, proposal, userId);

            return this.RedirectToAction(nameof(this.Details), new { id });
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

            return this.Redirect(nameof(this.All));
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
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.proposalService.DeleteByIdAsync(id, userId);

            return this.RedirectToAction(nameof(this.All));
        }

        [HttpPost]
        public async Task<IActionResult> SendToEmail(int id)
        {
            var targetEmail = this.User.FindFirstValue(ClaimTypes.Email);

            var proposal = await this.proposalService.GetByIdAsync<ProposalDetailsOutputViewModel>(id);
            var html = new StringBuilder();

            html.AppendLine($"<h1>{proposal.Title}</h1>");
            html.AppendLine($"<h3>{proposal.ShortDescription}</h3>");
            html.AppendLine($"<img src=\"{proposal.Images}\" />");
            html.AppendLine($"<h1>{proposal.Description}</h1>");

            await this.emailSender.SendEmailAsync(
                GlobalConstants.AdministratorEmail,
                GlobalConstants.SystemName,
                targetEmail,
                proposal.Title,
                html.ToString());

            return this.RedirectToAction(nameof(this.Details), new { id });
        }
    }
}
