namespace GreenCap.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using GreenCap.Common;
    using GreenCap.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class ImageSeeder : ISeeder
    {
        public async Task SeedAsync(IDeletableRepository dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Images.Any())
            {
                return;
            }

            var user = await dbContext.Users.Where(x => x.Email == GlobalConstants.AdministratorEmail).FirstOrDefaultAsync();

            // 19
            await dbContext.Images.AddAsync(new Image
            {
                AddedById = user.Id,
                Extension = "jpg",
                ProposalId = dbContext.Proposals.Where(x => x.Title == "Make Your Own").FirstOrDefault().Id,
                RemoteImageUrl = "/Images/Proposals/19.jpg",
            });

            // 1
            await dbContext.Images.AddAsync(new Image
            {
                AddedById = user.Id,
                Extension = "jpg",
                ProposalId = dbContext.Proposals.Where(x => x.Title == "Paper Grocery Bags").FirstOrDefault().Id,
                RemoteImageUrl = "/Images/Proposals/1.jpg",
            });

            await dbContext.Images.AddAsync(new Image
            {
                AddedById = user.Id,
                Extension = "jpg",
                ProposalId = dbContext.Proposals.Where(x => x.Title == "Mason Jars").FirstOrDefault().Id,
                RemoteImageUrl = "/Images/Proposals/2.jpg",
            });

            await dbContext.Images.AddAsync(new Image
            {
                AddedById = user.Id,
                Extension = "jpg",
                ProposalId = dbContext.Proposals.Where(x => x.Title == "Reusable Cloth Shopping Bags").FirstOrDefault().Id,
                RemoteImageUrl = "/Images/Proposals/3.jpg",
            });

            await dbContext.Images.AddAsync(new Image
            {
                AddedById = user.Id,
                Extension = "jpg",
                ProposalId = dbContext.Proposals.Where(x => x.Title == "Eco Alternatives to Sponges").FirstOrDefault().Id,
                RemoteImageUrl = "/Images/Proposals/4.jpg",
            });

            await dbContext.Images.AddAsync(new Image
            {
                AddedById = user.Id,
                Extension = "jpg",
                ProposalId = dbContext.Proposals.Where(x => x.Title == "Cardboard Boxes").FirstOrDefault().Id,
                RemoteImageUrl = "/Images/Proposals/5.jpg",
            });

            await dbContext.Images.AddAsync(new Image
            {
                AddedById = user.Id,
                Extension = "jpg",
                ProposalId = dbContext.Proposals.Where(x => x.Title == "Use LED light bulbs").FirstOrDefault().Id,
                RemoteImageUrl = "/Images/Proposals/6.jpg",
            });

            await dbContext.Images.AddAsync(new Image
            {
                AddedById = user.Id,
                Extension = "jpg",
                ProposalId = dbContext.Proposals.Where(x => x.Title == "Insulate your home").FirstOrDefault().Id,
                RemoteImageUrl = "/Images/Proposals/7.jpg",
            });

            await dbContext.Images.AddAsync(new Image
            {
                AddedById = user.Id,
                Extension = "jpg",
                ProposalId = dbContext.Proposals.Where(x => x.Title == "Use eco-friendly cleaning products").FirstOrDefault().Id,
                RemoteImageUrl = "/Images/Proposals/8.jpg",
            });

            await dbContext.Images.AddAsync(new Image
            {
                AddedById = user.Id,
                Extension = "jpg",
                ProposalId = dbContext.Proposals.Where(x => x.Title == "COMPOST YOUR FOOD WASTE").FirstOrDefault().Id,
                RemoteImageUrl = "/Images/Proposals/9.jpg",
            });

            await dbContext.Images.AddAsync(new Image
            {
                AddedById = user.Id,
                Extension = "jpg",
                ProposalId = dbContext.Proposals.Where(x => x.Title == "DITCH USING DISPOSABLE RAZORS").FirstOrDefault().Id,
                RemoteImageUrl = "/Images/Proposals/10.jpg",
            });

            await dbContext.Images.AddAsync(new Image
            {
                AddedById = user.Id,
                Extension = "jpg",
                ProposalId = dbContext.Proposals.Where(x => x.Title == "WATER HOUSE PLANTS WITH RAIN WATER").FirstOrDefault().Id,
                RemoteImageUrl = "/Images/Proposals/11.jpg",
            });

            await dbContext.Images.AddAsync(new Image
            {
                AddedById = user.Id,
                Extension = "jpg",
                ProposalId = dbContext.Proposals.Where(x => x.Title == "Wash Your Clothes In Cold Water").FirstOrDefault().Id,
                RemoteImageUrl = "/Images/Proposals/12.jpg",
            });

            await dbContext.Images.AddAsync(new Image
            {
                AddedById = user.Id,
                Extension = "jpg",
                ProposalId = dbContext.Proposals.Where(x => x.Title == "Skip The Dryer When Possible").FirstOrDefault().Id,
                RemoteImageUrl = "/Images/Proposals/13.jpg",
            });

            // 14
            await dbContext.Images.AddAsync(new Image
            {
                AddedById = user.Id,
                Extension = "jpg",
                ProposalId = dbContext.Proposals.Where(x => x.Title == "Use a Programmable Thermostat").FirstOrDefault().Id,
                RemoteImageUrl = "/Images/Proposals/14.jpg",
            });

            await dbContext.Images.AddAsync(new Image
            {
                AddedById = user.Id,
                Extension = "jpg",
                ProposalId = dbContext.Proposals.Where(x => x.Title == "Plant Herbs").FirstOrDefault().Id,
                RemoteImageUrl = "/Images/Proposals/15.jpg",
            });

            await dbContext.Images.AddAsync(new Image
            {
                AddedById = user.Id,
                Extension = "jpg",
                ProposalId = dbContext.Proposals.Where(x => x.Title == "Be Smarter In The Kitchen").FirstOrDefault().Id,
                RemoteImageUrl = "/Images/Proposals/16.jpg",
            });

            await dbContext.Images.AddAsync(new Image
            {
                AddedById = user.Id,
                Extension = "jpg",
                ProposalId = dbContext.Proposals.Where(x => x.Title == "Buy a Water Filter").FirstOrDefault().Id,
                RemoteImageUrl = "/Images/Proposals/17.jpg",
            });

            await dbContext.Images.AddAsync(new Image
            {
                AddedById = user.Id,
                Extension = "jpg",
                ProposalId = dbContext.Proposals.Where(x => x.Title == "Reduce Purchases").FirstOrDefault().Id,
                RemoteImageUrl = "/Images/Proposals/18.jpg",
            });

            await dbContext.Images.AddAsync(new Image
            {
                AddedById = user.Id,
                Extension = "jpg",
                ProposalId = dbContext.Proposals.Where(x => x.Title == "Encourage Hotels to Reduce Waste").FirstOrDefault().Id,
                RemoteImageUrl = "/Images/Proposals/20.jpg",
            });

            await dbContext.SaveChangesAsync();
        }
}
}
