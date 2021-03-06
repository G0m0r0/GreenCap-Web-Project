﻿namespace GreenCap.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using GreenCap.Services.Data.Contracts;
    using GreenCap.Web.ViewModels.EditViewModel;
    using GreenCap.Web.ViewModels.InputViewModels;
    using GreenCap.Web.ViewModels.OutputViewModel;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class EventsController : BaseController
    {
        private readonly IEventService eventService;

        public EventsController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        public IActionResult All(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int ItemsPerPage = 3;

            var viewModel = new EventsListOutputViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                EntitiesCount = this.eventService.GetCount(),
                Events = this.eventService.GetAll<EventOutputViewModel>(id, ItemsPerPage),
                AspAction = nameof(this.All),
            };

            return this.View(viewModel);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var inputModel = await this.eventService.GetByIdAsync<EventEditViewModel>(id);

            return this.View(inputModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(int id, EventEditViewModel eventModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await this.eventService.UpdateAsync(id, eventModel, userId);

            return this.RedirectToAction(nameof(this.All));
        }

        [Authorize]
        public IActionResult Donate()
        {
            return this.View();
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(EventInputViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await this.eventService.CreateAsync(model, userId);

            return this.RedirectToAction(nameof(this.All));
        }

        [Authorize]
        public async Task<IActionResult> Cancel(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.eventService.CancelEventAsync(id, userId);

            return this.RedirectToAction(nameof(this.All));
        }

        [Authorize]
        public async Task<IActionResult> Join(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.eventService.JoinEventAsync(id, userId);

            return this.RedirectToAction(nameof(this.All));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.eventService.DeleteByIdAsync(id, userId);

            return this.RedirectToAction(nameof(this.All));
        }
    }
}
