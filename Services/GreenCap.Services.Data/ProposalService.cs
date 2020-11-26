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
    using GreenCap.Web.ViewModels.OutputViewModel;
    using Microsoft.EntityFrameworkCore;

    public class ProposalService : IProposalService
    {
        private readonly IDeletableEntityRepository<Proposal> proposalDb;
        private readonly IDeletableEntityRepository<ApplicationUser> userDb;

        public ProposalService(IDeletableEntityRepository<Proposal> proposalDb, IDeletableEntityRepository<ApplicationUser> userDb)
        {
            this.proposalDb = proposalDb;
            this.userDb = userDb;
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

        // public async Task<IEnumerable<ProposalOutputViewModel>> GetAllAsync(int page, int itemsPerPage)
        // {
        //    return await this.proposalDb.All().Select(x => new ProposalOutputViewModel
        //    {
        //        Id = x.Id,
        //        Title = x.Title,
        //        ShortDescription = x.ShortDescription,
        //        CreatedOn = x.CreatedOn.ToLocalTime().ToString(FormatValidations.DateTimeFormat),
        //        Image = "https://cdn130.picsart.com/259427916032202.jpg?type=webp&to=crop&r=256",
        //    }).ToListAsync();
        // }
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

        public int GetCount()
        {
            return this.proposalDb.All().Count();
        }

        public async Task<IEnumerable<ProposalOutputViewModel>> GetAllForSignedInUserAsync(string id)
        {
            return await this.proposalDb.All().Where(x => x.CreatedById == id).Select(x => new ProposalOutputViewModel
            {
                Id = x.Id,
                Title = x.Title,
                ShortDescription = x.ShortDescription,
                CreatedOn = x.CreatedOn.ToLocalTime().ToString(FormatValidations.DateTimeFormat),
                Image = "https://cdn130.picsart.com/259427916032202.jpg?type=webp&to=crop&r=256",
            }).ToListAsync();
        }

        public async Task<ProposalOutputViewModel> GetByIdAsync(int id)
        {
            return await this.proposalDb.All().Where(x => x.Id == id).Select(x => new ProposalOutputViewModel
            {
                Id = x.Id,
                CreatedByName = this.userDb.All().Where(y => y.Id == x.CreatedById).FirstOrDefault().UserName ?? FormatValidations.DefaultUserName,
                Title = x.Title,
                CreatedOn = x.CreatedOn.ToLocalTime().ToString(FormatValidations.DateTimeFormat),
                Description = x.Description,
                ModifiedOn = (x.ModifiedOn == null) ? FormatValidations.DateTimeNeverModified : x.ModifiedOn.ToString(),
            }).FirstOrDefaultAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var modelToDelete = await this.proposalDb.All().FirstOrDefaultAsync(x => x.Id == id);

            if (modelToDelete == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.ProposalNotFound));
            }

            modelToDelete.IsDeleted = true;
            modelToDelete.DeletedOn = DateTime.UtcNow;
            this.proposalDb.Update(modelToDelete);

            await this.proposalDb.SaveChangesAsync();
        }
    }
}
