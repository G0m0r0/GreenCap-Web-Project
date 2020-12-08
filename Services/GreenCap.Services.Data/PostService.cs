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

        public IEnumerable<T> GetAllPersonal<T>(int page, int itemsPerPage, string userId)
        {
            return this.forumDb
                .AllAsNoTracking()
                .Where(x => x.CreatedById == userId)
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

        public async Task UpdateAsync(int id, PostEditViewModel input, string userId)
        {
            var post = await this.forumDb.All().FirstOrDefaultAsync(x => x.Id == id);

            if (post.User.Id != userId)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.YouHaveToBeCreatorException, post.ProblemTitle));
            }

            if (post == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.PostNotFound));
            }

            post.ProblemTitle = input.ProblemTitle;
            post.Description = input.Description;
            post.Category = input.Category;

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

            this.forumDb.Delete(modelToDelete);

            await this.forumDb.SaveChangesAsync();
        }

        public int GetCount()
        {
            return this.forumDb.All().Count();
        }

        public int GetCountPersonal(string userId)
        {
            return this.forumDb.All().Where(x => x.CreatedById == userId).Count();
        }

        public int GetCountByCategory(string categoryName)
        {
            return this.forumDb.All().Where(x => x.Category.ToString() == categoryName).Count();
        }
    }
}
