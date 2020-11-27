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
    using GreenCap.Web.ViewModels.InputViewModels;
    using Microsoft.EntityFrameworkCore;

    public class ProposalService : IProposalService
    {
        private readonly IDeletableEntityRepository<Proposal> proposalDb;

        public ProposalService(IDeletableEntityRepository<Proposal> proposalDb)
        {
            this.proposalDb = proposalDb;
        }

        public async Task CreateAsync(ProposalViewModel model, string id)
        {
            var proposal = new Proposal
            {
                Title = model.Title,
                ShortDescription = model.ShortDescription,
                Description = model.Description,
                CreatedById = id,
            };

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

        public IEnumerable<T> GetAllPersonal<T>(int page, int itemsPerPage, string id)
        {
            return this.proposalDb
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
            return await this.proposalDb
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();
        }

        public async Task DeleteByIdAsync(int id, string userId)
        {
            var modelToDelete = await this.proposalDb.All().FirstOrDefaultAsync(x => x.Id == id);

            if (modelToDelete.CreatedById != userId)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.YouHaveToBeCreatorException, modelToDelete.Title));
            }

            if (modelToDelete == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.ProposalNotFound));
            }

            modelToDelete.IsDeleted = true;
            modelToDelete.DeletedOn = DateTime.UtcNow;
            this.proposalDb.Update(modelToDelete);

            await this.proposalDb.SaveChangesAsync();
        }

        public int GetCount()
        {
            return this.proposalDb.All().Count();
        }

        public int GetCountPersonal(string id)
        {
            return this.proposalDb.All().Where(x => x.CreatedById == id).Count();
        }
    }
}
