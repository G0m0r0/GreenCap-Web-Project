namespace GreenCap.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using GreenCap.Data.Common.Repositories;

    using GreenCap.Data.Models;
    using GreenCap.Services.Data.Common;
    using GreenCap.Services.Data.Contracts;
    using GreenCap.Services.Mapping;
    using GreenCap.Web.ViewModels.EditViewModel;
    using GreenCap.Web.ViewModels.InputViewModels;
    using Microsoft.EntityFrameworkCore;

    public class ProposalService : IProposalService
    {
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif" };
        private readonly IDeletableEntityRepository<Proposal> proposalDb;

        public ProposalService(IDeletableEntityRepository<Proposal> proposalDb)
        {
            this.proposalDb = proposalDb;
        }

        public async Task CreateAsync(ProposalViewModel model, string userId, string imagePath)
        {
            var proposal = new Proposal
            {
                Title = model.Title,
                ShortDescription = model.ShortDescription,
                Description = model.Description,
                CreatedById = userId,
            };

            // image sharp to say if its real photo
            // /wwwroot/images/recipes/{id}.{ext}
            Directory.CreateDirectory($"{imagePath}/Proposals/");
            foreach (var image in model.Images)
            {
                var extension = Path.GetExtension(image.FileName).TrimStart('.');
                if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
                {
                    throw new Exception(string.Format(ExceptionMessages.InvalidImageExtentionException, extension));
                }

                var dbImage = new Image
                {
                    AddedById = userId,
                    Extension = extension,
                };
                proposal.Images.Add(dbImage);

                var physicalPath = $"{imagePath}/Proposals/{dbImage.Id}.{extension}";
                using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
                await image.CopyToAsync(fileStream);
            }

            await this.proposalDb.AddAsync(proposal);
            await this.proposalDb.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage)
        {
            return this.proposalDb
                .AllAsNoTracking()
                .OrderByDescending(x => x.CreatedOn)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<T>()
                .ToList();
        }

        public IEnumerable<T> GetAllPersonal<T>(int page, int itemsPerPage, string userId)
        {
            return this.proposalDb
                .AllAsNoTracking()
                .Where(x => x.User.Id == userId)
                .OrderByDescending(x => x.CreatedOn)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<T>()
                .ToList();
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            return await this.proposalDb
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(int id, ProposalEditViewModel input, string userId)
        {
            var proposal = await this.proposalDb.All().FirstOrDefaultAsync(x => x.Id == id);

            if (proposal.User.Id != userId)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.YouHaveToBeCreatorException, proposal.Title));
            }

            if (proposal == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.ProposalNotFound));
            }

            proposal.Title = input.Title;
            proposal.Description = input.Description;
            proposal.ShortDescription = input.ShortDescription;

            await this.proposalDb.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id, string userId)
        {
            var modelToDelete = await this.proposalDb.All().FirstOrDefaultAsync(x => x.Id == id);

            if (modelToDelete.CreatedById != userId)
            {
                throw new NullReferenceException(
                    string.Format(ExceptionMessages.YouHaveToBeCreatorException, modelToDelete.Title));
            }

            if (modelToDelete == null)
            {
                throw new NullReferenceException(
                    string.Format(ExceptionMessages.ProposalNotFound, modelToDelete.Title));
            }

            this.proposalDb.Delete(modelToDelete);

            await this.proposalDb.SaveChangesAsync();
        }

        public int GetCount()
        {
            return this.proposalDb.All().Count();
        }

        public int GetCountPersonal(string userId)
        {
            return this.proposalDb.All().Where(x => x.User.Id == userId).Count();
        }
    }
}
