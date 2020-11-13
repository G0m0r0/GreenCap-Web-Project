namespace GreenCap.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GreenCap.Data.Common.Repositories;

    using GreenCap.Data.Models;
    using GreenCap.Web.ViewModels.InputViewModels;
    using GreenCap.Web.ViewModels.OutputViewModel;

    public class ProposalService : IProposalService
    {
        private readonly IDeletableEntityRepository<Proposal> proposalDb;
        private readonly IDeletableEntityRepository<ApplicationUser> userDb;

        public ProposalService(IDeletableEntityRepository<Proposal> proposalDb, IDeletableEntityRepository<ApplicationUser> userDb)
        {
            this.proposalDb = proposalDb;
            this.userDb = userDb;
        }

        public async Task CreateAsync(ProposalInputViewModel model, string id)
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

        public int Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProposalOutputViewModel> GetAll()
        {
            return this.proposalDb.All().Select(x => new ProposalOutputViewModel
            {
                Id = x.Id,
                Title = x.Title,
                ShortDescription = x.ShortDescription,
                CreatedOn = x.CreatedOn.ToLocalTime().ToString("dd/MMM/yyyy"),
                Image = "https://cdn130.picsart.com/259427916032202.jpg?type=webp&to=crop&r=256",
            });
        }

        public ProposalOutputViewModel GetById(int id)
        {
            return this.proposalDb.All().Where(x => x.Id == id).Select(x => new ProposalOutputViewModel
            {
                Id = x.Id,
                CreatedByName = this.userDb.All().Where(y => y.Id == x.CreatedById).FirstOrDefault().UserName,
                Title = x.Title,
                CreatedOn = x.CreatedOn.ToLocalTime().ToString("dd/MMM/yyyy"),
                Description = x.Description,
                ModifiedOn = (x.ModifiedOn == null) ? "Never modified." : x.ModifiedOn.ToString(),
            }).FirstOrDefault();
        }
    }
}
