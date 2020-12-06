namespace GreenCap.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using GreenCap.Data;
    using GreenCap.Data.Common.Repositories;
    using GreenCap.Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    [Area("Administration")]
    public class ProposalsController : AdministrationController
    {
        private readonly IDeletableEntityRepository<Proposal> context;
        private readonly IDeletableEntityRepository<ApplicationUser> userDb;

        public ProposalsController(IDeletableEntityRepository<Proposal> context, IDeletableEntityRepository<ApplicationUser> userDb)
        {
            this.context = context;
            this.userDb = userDb;
        }

        // GET: Administration/Proposals
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = this.context.AllWithDeleted().Include(p => p.User);
            return this.View(await applicationDbContext.ToListAsync());
        }

        // GET: Administration/Proposals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var proposal = await this.context.All()
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proposal == null)
            {
                return this.NotFound();
            }

            return this.View(proposal);
        }

        // GET: Administration/Proposals/Create
        public IActionResult Create()
        {
            this.ViewData["CreatedById"] = new SelectList(this.userDb.All(), "Id", "Id");
            return this.View();
        }

        // POST: Administration/Proposals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,ShortDescription,CreatedById,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Proposal proposal)
        {
            if (this.ModelState.IsValid)
            {
                await this.context.AddAsync(proposal);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            this.ViewData["CreatedById"] = new SelectList(this.userDb.All(), "Id", "Id", proposal.CreatedById);
            return this.View(proposal);
        }

        // GET: Administration/Proposals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var proposal = await this.context.All().FirstOrDefaultAsync(x => x.Id == id);
            if (proposal == null)
            {
                return this.NotFound();
            }

            this.ViewData["CreatedById"] = new SelectList(this.userDb.All(), "Id", "Id", proposal.CreatedById);
            return this.View(proposal);
        }

        // POST: Administration/Proposals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Description,ShortDescription,CreatedById,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Proposal proposal)
        {
            if (id != proposal.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(proposal);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.ProposalExists(proposal.Id))
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

            this.ViewData["CreatedById"] = new SelectList(this.userDb.All(), "Id", "Id", proposal.CreatedById);
            return this.View(proposal);
        }

        // GET: Administration/Proposals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var proposal = await this.context.All()
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proposal == null)
            {
                return this.NotFound();
            }

            return this.View(proposal);
        }

        // POST: Administration/Proposals/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proposal = await this.context.All().FirstOrDefaultAsync(x => x.Id == id);
            this.context.Delete(proposal);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool ProposalExists(int id)
        {
            return this.context.All().Any(e => e.Id == id);
        }
    }
}
