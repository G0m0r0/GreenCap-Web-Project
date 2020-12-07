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
    using GreenCap.Web.ViewModels.EditViewModel;
    using GreenCap.Web.ViewModels.InputViewModels;
    using GreenCap.Web.ViewModels.OutputViewModel;
    using Microsoft.EntityFrameworkCore;

    public class PostService : IPostservice
    {
        private readonly IDeletableEntityRepository<Post> forumDb;

        public PostService(IDeletableEntityRepository<Post> forumDb)
        {
            this.forumDb = forumDb;
        }

        public async Task CreateAsync(PostInputViewModel model, string id)
        {
            var modelToCreate = new Post
            {
                ProblemTitle = model.ProblemTitle,
                Category = model.Category,
                CreatedById = id,
                Description = model.Description,
            };

            await this.forumDb.AddAsync(modelToCreate);
            await this.forumDb.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage)
        {
            return this.forumDb
                .AllAsNoTracking()
                .OrderByDescending(x => x.CreatedOn)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<T>()
                .ToList();
        }

        public IEnumerable<T> GetAllPersonal<T>(int page, int itemsPerPage, string id)
        {
            return this.forumDb
                .AllAsNoTracking()
                .Where(x => x.CreatedById == id)
                .OrderByDescending(x => x.CreatedOn)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<T>()
                .ToList();
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            return await this.forumDb
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(int id, PostEditViewModel input)
        {
            var proposal = await this.forumDb.All().FirstOrDefaultAsync(x => x.Id == id);

            proposal.ProblemTitle = input.ProblemTitle;
            proposal.Description = input.Description;
            proposal.Category = input.Category;

            await this.forumDb.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id, string userId)
        {
            var modelToDelete = await this.forumDb.All().FirstOrDefaultAsync(x => x.Id == id);

            if (modelToDelete.CreatedById != userId)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.YouHaveToBeCreatorException, modelToDelete.ProblemTitle));
            }

            if (modelToDelete == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.PostNotFound));
            }

            modelToDelete.IsDeleted = true;
            modelToDelete.DeletedOn = DateTime.UtcNow;
            this.forumDb.Update(modelToDelete);

            await this.forumDb.SaveChangesAsync();
        }

        public int GetCount()
        {
            return this.forumDb.All().Count();
        }

        public int GetCountPersonal(string id)
        {
            return this.forumDb.All().Where(x => x.CreatedById == id).Count();
        }

        public int GetCountByCategory(string categoryName)
        {
            return this.forumDb.All().Where(x => x.Category.ToString() == categoryName).Count();
        }
    }
}
