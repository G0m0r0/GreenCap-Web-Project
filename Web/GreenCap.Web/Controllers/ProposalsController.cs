namespace GreenCap.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using GreenCap.Services.Data.Contracts;
    using GreenCap.Web.ViewModels.InputViewModels;
    using GreenCap.Web.ViewModels.OutputViewModel;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;

    public class ProposalsController : BaseController
    {
        private readonly IProposalService proposalService;

        public ProposalsController( IProposalService proposalService)
        {
            this.proposalService = proposalService;
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
            };

            return this.View(viewModel);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProposalViewModel proposal)
        {
            // if (!proposal.Image.FileName.EndsWith(".png") || !proposal.Image.FileName.EndsWith(".jpeg"))
            // {
            //     this.ModelState.AddModelError("Image", "Invalid file type. Supported .png and .jpeg!");
            // }
            //
            // if (proposal.Image.Length > 10 * 1024 * 1024)
            // {
            //     this.ModelState.AddModelError("Image", "File size is over 10Mb.");
            // }
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            // using (FileStream fs = new FileStream(
            //     this.webHostEnvironment.WebRootPath + "/user.png", FileMode.Create))
            // {
            //     await proposal.Image.CopyToAsync(fs);
            // }

            // get id from cookie
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await this.proposalService.CreateAsync(proposal, userId);

            return this.Redirect("All");
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await this.proposalService.GetByIdAsync<ProposalDetailsOutputViewModel>(id);
            return this.View(model);
        }

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
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.proposalService.DeleteByIdAsync(id, userId);

            return this.Redirect("All");
        }
    }
}
