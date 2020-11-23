namespace GreenCap.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GreenCap.Data.Common.Repositories;
    using GreenCap.Data.Models;
    using GreenCap.Services.Data.Common;
    using GreenCap.Services.Data.Contracts;
    using GreenCap.Web.ViewModels.OutputViewModel;
    using Microsoft.EntityFrameworkCore;

    public class NewsService : INewsService
    {
        private readonly IDeletableEntityRepository<News> newsDb;

        public NewsService(IDeletableEntityRepository<News> newsDb)
        {
            this.newsDb = newsDb;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var modelToDelete = await this.newsDb.All().FirstOrDefaultAsync(x => x.Id == id);

            if (modelToDelete == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.NewsNotFound));
            }

            modelToDelete.IsDeleted = true;
            modelToDelete.DeletedOn = DateTime.UtcNow;
            this.newsDb.Update(modelToDelete);

            await this.newsDb.SaveChangesAsync();
        }

        public async Task<IEnumerable<NewsOutputViewModel>> GetAllAsync()
        {
            return await this.newsDb.All().Select(x => new NewsOutputViewModel
            {
                Id = x.Id,
                Title = x.Title,
                SmallPhotoUrl = x.ImageSmallUrl,
                PostedOn = x.PostedOn,
                CategoryName = x.Category.Name,
                Summary = x.Summary,
            }).ToListAsync();
        }

        public async Task<NewsOutputViewModel> GetByIdAsync(int id)
        {
            return await this.newsDb.All().Where(x => x.Id == id).Select(x => new NewsOutputViewModel
            {
                Id = x.Id,
                Title = x.Title,
                MainPageUrl = x.OriginalUrl,
                ImageUrl = x.ImageUrl,
                PostedOn = x.PostedOn,
                CategoryName = x.Category.Name,
                Credit = x.Credit,
                MainText = x.Description,
            }).FirstOrDefaultAsync();
        }
    }
}
