namespace GreenCap.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using GreenCap.Data.Models;

    using Microsoft.EntityFrameworkCore.Internal;

    public class ProposalsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Proposals.Any())
            {
                return;
            }

            await dbContext.Proposals.AddAsync(new Proposal
            {
                Title = "Paper Grocery Bags",
                ShortDescription = "Plastic bags are convenient for consumers but the sad truth is they're harmful to the environment.",
                Description = "Plastic bags made from non-renewable crude oil aren’t biodegradable, and it takes millions of barrels of oil to produce them every year. Once made it’s nearly impossible to get rid of them. It can take as long as 400 years for one plastic bag to break down. That creates pollution problems and dangerous situations for any wildlife swallowing plastic particles. So the next time you’re at the grocery store and the cashier asks if you want paper or plastic, choose paper.",
                CreatedById = "1",
            });

            await dbContext.Proposals.AddAsync(new Proposal
            {
                Title = "Mason Jars",
                ShortDescription = "Use jars for storage!",
                Description = "Alternatives to plastic bags for storage come in all shapes and sizes, including the ever-popular Mason jar. Storing food in glass jars has been common for many years (it’s something your grandparents probably did), and it has several advantages over plastic bags. Jars can be recycled, or washed and reused indefinitely — a true money saver. Food stored in jars tastes fresher because the glass doesn’t absorb odors from other foods in the fridge. They’re also food safe and don’t leak. And glass doesn’t contain toxins.",
                CreatedById = "1",
            });

            await dbContext.Proposals.AddAsync(new Proposal
            {
                Title = "Reusable Cloth Shopping Bags",
                ShortDescription = "Better alternatives of plastic bags.",
                Description = "Many grocery stores offer the option of paper, plastic or the purchase of their reusable shopping bags. The bags are usually displayed throughout the store, as well as at the customer service counter and the cash register. They come in a variety of colors, perhaps with the company logo, and some are festive for the holidays. They’re usually from a durable inexpensive material or fabric. Some grocery chains ask shoppers to pay for plastic bags. By purchasing an eco-friendly recyclable shopping bag, you’re helping the planet and saving money, too  — as long as you remember to bring them.",
                CreatedById = "1",
            });

            await dbContext.Proposals.AddAsync(new Proposal
            {
                Title = "Eco Alternatives to Sponges",
                ShortDescription = "Sustainable Deeds. Plant based cleaning - Alternative to plastic sponges",
                Description = "Did you know that most regular washing up sponges are made from synthetic and plastic fibres, and that each time you use a sponge those fibres are released straight into the water system? What can we do about this issue? As is often the case the natural world has an answer. This time it is in the form of the Luffa Cylindrica plant.This plant, which is part of the cucumber family and native to Asia, is also commonly known as a loofah plant or sponge gourd.Luffah fruits are edible when they are young and as they mature they become more fibrous and suitable for sponge production. When dried and peeled the luffah plant reveals a skeleton that is stiff with a wire like texture, which when hydrated makes for a perfect sponge.",
                CreatedById = "1",
            });

            await dbContext.Proposals.AddAsync(new Proposal
            {
                Title = "Cardboard Boxes",
                ShortDescription = "Useful storage!",
                Description = "Ask your store if it has a stash of free cardboard boxes and use one or two to carry your groceries. Some chains have them readily available at checkout so groceries can be packed as they’re checked. They come in all shapes and sizes. Along with being strong and durable, cardboard boxes are recyclable. Whenever you buy something shipped in a cardboard box, reuse it at the grocery store if your local market doesn’t provide free ones for its customers.",
                CreatedById = "1",
            });

            await dbContext.SaveChangesAsync();
        }
    }
}
