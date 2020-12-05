namespace GreenCap.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using GreenCap.Data;
    using GreenCap.Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    [Area("Administration")]
    public class PostsController : AdministrationController
    {
        private readonly ApplicationDbContext context;

        public PostsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: Administration/Posts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = this.context.Posts.Include(p => p.User);
            return this.View(await applicationDbContext.ToListAsync());
        }

        // GET: Administration/Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var post = await this.context.Posts
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return this.NotFound();
            }

            return this.View(post);
        }

        // GET: Administration/Posts/Create
        public IActionResult Create()
        {
            this.ViewData["CreatedById"] = new SelectList(this.context.Users, "Id", "Id");
            return this.View();
        }

        // POST: Administration/Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProblemTitle,Description,CreatedById,Category,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Post post)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Add(post);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            this.ViewData["CreatedById"] = new SelectList(this.context.Users, "Id", "Id", post.CreatedById);
            return this.View(post);
        }

        // GET: Administration/Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var post = await this.context.Posts.FindAsync(id);
            if (post == null)
            {
                return this.NotFound();
            }

            this.ViewData["CreatedById"] = new SelectList(this.context.Users, "Id", "Id", post.CreatedById);
            return this.View(post);
        }

        // POST: Administration/Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProblemTitle,Description,CreatedById,Category,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Post post)
        {
            if (id != post.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(post);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.PostExists(post.Id))
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

            this.ViewData["CreatedById"] = new SelectList(this.context.Users, "Id", "Id", post.CreatedById);
            return this.View(post);
        }

        // GET: Administration/Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var post = await this.context.Posts
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return this.NotFound();
            }

            return this.View(post);
        }

        // POST: Administration/Posts/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = await this.context.Posts.FindAsync(id);
            this.context.Posts.Remove(post);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool PostExists(int id)
        {
            return this.context.Posts.Any(e => e.Id == id);
        }
    }
}
