namespace GreenCap.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GreenCap.Data.Common.Repositories;
    using GreenCap.Data.Models;
    using GreenCap.Data.Models.Enums;
    using GreenCap.Services.Data.Common;
    using GreenCap.Services.Data.Contracts;
    using GreenCap.Services.Data.Exceptions;
    using GreenCap.Services.Mapping;
    using GreenCap.Web.ViewModels.EditViewModel;
    using GreenCap.Web.ViewModels.InputViewModels;
    using Microsoft.EntityFrameworkCore;

    public class PostService : IPostservice
    {
        private readonly IDeletableEntityRepository<Post> forumDb;
        private readonly IDeletableEntityRepository<ApplicationUser> userDb;

        public PostService(IDeletableEntityRepository<Post> forumDb, IDeletableEntityRepository<ApplicationUser> userDb)
        {
            this.forumDb = forumDb;
            this.userDb = userDb;
        }

        public async Task CreateAsync(PostInputViewModel model, string userId)
        {
            var modelToCreate = new Post
            {
                ProblemTitle = model.ProblemTitle,
                Category = model.Category,
                CreatedById = userId,
                Description = model.Description,
            };

            await this.forumDb.AddAsync(modelToCreate);
            await this.forumDb.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage)
        {
            CheckIfPageAndItemsPerPageIsCorrect(page, itemsPerPage);

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
            CheckIfPageAndItemsPerPageIsCorrect(page, itemsPerPage);

            if (!this.userDb.All().Any(x => x.Id == userId))
            {
                throw new NullReferenceException(ExceptionMessages.UserDoesNotExist);
            }

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
            CheckIfIdIsCorrect(id);

            return await this.forumDb
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(int id, PostEditViewModel input, string userId)
        {
            var post = await this.forumDb.All().FirstOrDefaultAsync(x => x.Id == id);

            if (post == null)
            {
                throw new NullReferenceException(ExceptionMessages.PostNotFound);
            }

            if (post.CreatedById != userId)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.YouHaveToBeCreatorException, post.ProblemTitle));
            }

            post.ProblemTitle = input.ProblemTitle;
            post.Description = input.Description;
            post.Category = input.Category;

            await this.forumDb.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id, string userId)
        {
            var modelToDelete = await this.forumDb.All().FirstOrDefaultAsync(x => x.Id == id);

            if (modelToDelete == null)
            {
                throw new NullReferenceException(ExceptionMessages.PostNotFound);
            }

            if (modelToDelete.CreatedById != userId)
            {
                throw new NullReferenceException(
                    string.Format(ExceptionMessages.YouHaveToBeCreatorException, modelToDelete.ProblemTitle));
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
            bool exist = this.userDb.All().Any(x => x.Id == userId);
            if (!exist)
            {
                throw new NullReferenceException(ExceptionMessages.UserDoesNotExist);
            }

            return this.forumDb.All().Where(x => x.CreatedById == userId).Count();
        }

        public int GetCountByCategory(string categoryName)
        {
            if (string.IsNullOrWhiteSpace(categoryName))
            {
                throw new NullReferenceException(ExceptionMessages.CategoryIsNull);
            }

            bool categoryExists = Enum.IsDefined(
                typeof(Category), categoryName);

            if (!categoryExists)
            {
                throw new NullReferenceException(ExceptionMessages.CategoryNameDoesNotExist);
            }

            return this.forumDb.All().Where(x => x.Category.ToString() == categoryName).Count();
        }

        private static void CheckIfIdIsCorrect(int id)
        {
            if (id < 0)
            {
                throw new NegativeNumberNotAllowedException(
                    string.Format(ExceptionMessages.CanNotBeNegativeNumber, nameof(id)));
            }
        }

        private static void CheckIfPageAndItemsPerPageIsCorrect(int page, int itemsPerPage)
        {
            if (page < 0)
            {
                throw new NegativeNumberNotAllowedException(
                    string.Format(ExceptionMessages.CanNotBeNegativeNumber, nameof(page)));
            }

            if (itemsPerPage < 0)
            {
                throw new NegativeNumberNotAllowedException(
                    string.Format(ExceptionMessages.CanNotBeNegativeNumber, nameof(itemsPerPage)));
            }
        }
    }
}
