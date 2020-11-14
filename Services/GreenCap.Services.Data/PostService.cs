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
    using GreenCap.Web.ViewModels.InputViewModels;
    using GreenCap.Web.ViewModels.OutputViewModel;
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

        public async Task DeleteByIdAsync(int id)
        {
            var modelToDelete = await this.forumDb.All().FirstOrDefaultAsync(x => x.Id == id);

            if (modelToDelete == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.PostNotFound));
            }

            modelToDelete.IsDeleted = true;
            modelToDelete.DeletedOn = DateTime.UtcNow;
            this.forumDb.Update(modelToDelete);

            await this.forumDb.SaveChangesAsync();
        }

        public async Task<IEnumerable<PostOutputViewModel>> GetAllAsync()
        {
            return await this.forumDb.All().Select(x => new PostOutputViewModel
            {
                Title = x.ProblemTitle,
                CreatorName = this.userDb.All().Where(y => y.Id == x.CreatedById).FirstOrDefault().UserName,
                Category = x.Category.ToString(),
                Description = x.Description,
                PostedOn = x.CreatedOn.ToLocalTime().ToString(FormatValidations.DateTimeFormat),
                Likes = x.UsersLikes.Where(x => x.IsPositive == true).Count(),
                DissLikes = x.UsersLikes.Where(x => x.IsPositive == false).Count(),
            }).ToListAsync();
        }

        public async Task<IEnumerable<PostOutputViewModel>> GetAllForSignedInUserAsync(string id)
        {
            return await this.forumDb.All().Where(x => x.CreatedById == id).Select(x => new PostOutputViewModel
            {
                Title = x.ProblemTitle,
                CreatorName = this.userDb.All().Where(y => y.Id == x.CreatedById).FirstOrDefault().UserName,
                Category = x.Category.ToString(),
                Description = x.Description,
                PostedOn = x.CreatedOn.ToLocalTime().ToString(FormatValidations.DateTimeFormat),
                Likes = x.UsersLikes.Where(x => x.IsPositive == true).Count(),
                DissLikes = x.UsersLikes.Where(x => x.IsPositive == false).Count(),
            }).ToListAsync();
        }

        public async Task<PostOutputViewModel> GetByIdAsync(int id)
        {
            return await this.forumDb.All().Where(x => x.Id == id).Select(x => new PostOutputViewModel
            {
                Title = x.ProblemTitle,
                CreatorName = this.userDb.All().Where(y => y.Id == x.CreatedById).FirstOrDefault().UserName,
                Category = x.Category.ToString(),
                Description = x.Description,
                PostedOn = x.CreatedOn.ToLocalTime().ToString(FormatValidations.DateTimeFormat),
                Likes = x.UsersLikes.Where(x => x.IsPositive == true).Count(),
                DissLikes = x.UsersLikes.Where(x => x.IsPositive == false).Count(),
            }).FirstOrDefaultAsync();
        }
    }
}
