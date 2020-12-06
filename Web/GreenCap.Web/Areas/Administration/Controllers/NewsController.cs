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
    public class NewsController : AdministrationController
    {
        private readonly IDeletableEntityRepository<News> context;
        private readonly IDeletableEntityRepository<CategoryNews> categoryNewsDb;

        public NewsController(IDeletableEntityRepository<News> context, IDeletableEntityRepository<CategoryNews> categoryNewsDb)
        {
            this.context = context;
            this.categoryNewsDb = categoryNewsDb;
        }

        // GET: Administration/News
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = this.context.AllWithDeleted().Include(n => n.Category);
            return this.View(await applicationDbContext.ToListAsync());
        }

        // GET: Administration/News/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var news = await this.context.All()
                .Include(n => n.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (news == null)
            {
                return this.NotFound();
            }

            return this.View(news);
        }

        // GET: Administration/News/Create
        public IActionResult Create()
        {
            this.ViewData["CategoryId"] = new SelectList(this.categoryNewsDb.All(), "Id", "Name");
            return this.View();
        }

        // POST: Administration/News/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,ImageUrl,Credit,Description,PostedOn,Summary,OriginalUrl,ImageSmallUrl,CategoryId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] News news)
        {
            if (this.ModelState.IsValid)
            {
                await this.context.AddAsync(news);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            this.ViewData["CategoryId"] = new SelectList(this.categoryNewsDb.All(), "Id", "Name", news.CategoryId);
            return this.View(news);
        }

        // GET: Administration/News/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var news = await this.context.All().FirstOrDefaultAsync(x => x.Id == id);
            if (news == null)
            {
                return this.NotFound();
            }

            this.ViewData["CategoryId"] = new SelectList(this.categoryNewsDb.All(), "Id", "Name", news.CategoryId);
            return this.View(news);
        }

        // POST: Administration/News/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,ImageUrl,Credit,Description,PostedOn,Summary,OriginalUrl,ImageSmallUrl,CategoryId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] News news)
        {
            if (id != news.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(news);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.NewsExists(news.Id))
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

            this.ViewData["CategoryId"] = new SelectList(this.categoryNewsDb.All(), "Id", "Name", news.CategoryId);
            return this.View(news);
        }

        // GET: Administration/News/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var news = await this.context.All()
                .Include(n => n.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (news == null)
            {
                return this.NotFound();
            }

            return this.View(news);
        }

        // POST: Administration/News/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var news = await this.context.All().FirstOrDefaultAsync(x => x.Id == id);
            this.context.Delete(news);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool NewsExists(int id)
        {
            return this.context.All().Any(e => e.Id == id);
        }
    }
}
