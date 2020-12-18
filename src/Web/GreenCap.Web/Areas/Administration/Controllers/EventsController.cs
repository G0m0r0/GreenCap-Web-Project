namespace GreenCap.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using GreenCap.Data.Common.Repositories;
    using GreenCap.Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Area("Administration")]
    public class EventsController : AdministrationController
    {
        private readonly IDeletableEntityRepository<Event> context;

        public EventsController(IDeletableEntityRepository<Event> context)
        {
            this.context = context;
        }

        // GET: Administration/Events
        public async Task<IActionResult> Index()
        {
            return this.View(await this.context.AllAsNoTrackingWithDeleted().ToListAsync());
        }

        // GET: Administration/Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var @event = await this.context.AllAsNoTrackingWithDeleted()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return this.NotFound();
            }

            return this.View(@event);
        }

        // GET: Administration/Events/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Administration/Events/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,ImagePath,StartDate,EndDate,TotalPeople,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Event @event)
        {
            if (this.ModelState.IsValid)
            {
                await this.context.AddAsync(@event);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(@event);
        }

        // GET: Administration/Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var @event = await this.context.AllAsNoTrackingWithDeleted().FirstOrDefaultAsync(x => x.Id == id);
            if (@event == null)
            {
                return this.NotFound();
            }

            return this.View(@event);
        }

        // POST: Administration/Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Description,ImagePath,StartDate,EndDate,TotalPeople,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Event @event)
        {
            if (id != @event.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(@event);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.EventExists(@event.Id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(@event);
        }

        // GET: Administration/Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var @event = await this.context.AllAsNoTrackingWithDeleted()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return this.NotFound();
            }

            return this.View(@event);
        }

        // POST: Administration/Events/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await this.context.AllAsNoTrackingWithDeleted().FirstOrDefaultAsync(x => x.Id == id);
            this.context.Delete(@event);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool EventExists(int id)
        {
            return this.context.AllAsNoTrackingWithDeleted().Any(e => e.Id == id);
        }
    }
}
