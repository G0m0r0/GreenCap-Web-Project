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
    using GreenCap.Services.Mapping;
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

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage)
        {
            return this.newsDb
                .AllAsNoTracking()
                .OrderByDescending(x => x.CreatedOn)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<T>()
                .ToList();
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            return await this.newsDb
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();
        }

        public int GetCount()
        {
            return this.newsDb.All().Count();
        }
    }
}
