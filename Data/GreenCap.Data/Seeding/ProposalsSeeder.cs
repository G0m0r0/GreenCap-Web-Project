namespace GreenCap.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GreenCap.Common;
    using GreenCap.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class ProposalsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Proposals.Any())
            {
                return;
            }

            var user = await dbContext.Users.Where(x => x.Email == GlobalConstants.AdministratorEmail).FirstOrDefaultAsync();

            await dbContext.Proposals.AddAsync(new Proposal
            {
                Title = "Paper Grocery Bags",
                ShortDescription = "Plastic bags are convenient for consumers but the sad truth is they're harmful to the environment.",
                Description = "Plastic bags made from non-renewable crude oil aren’t biodegradable, and it takes millions of barrels of oil to produce them every year. Once made it’s nearly impossible to get rid of them. It can take as long as 400 years for one plastic bag to break down. That creates pollution problems and dangerous situations for any wildlife swallowing plastic particles. So the next time you’re at the grocery store and the cashier asks if you want paper or plastic, choose paper.",
                CreatedById = user.Id,
            });

            await dbContext.Proposals.AddAsync(new Proposal
            {
                Title = "Mason Jars",
                ShortDescription = "Use jars for storage!",
                Description = "Alternatives to plastic bags for storage come in all shapes and sizes, including the ever-popular Mason jar. Storing food in glass jars has been common for many years (it’s something your grandparents probably did), and it has several advantages over plastic bags. Jars can be recycled, or washed and reused indefinitely — a true money saver. Food stored in jars tastes fresher because the glass doesn’t absorb odors from other foods in the fridge. They’re also food safe and don’t leak. And glass doesn’t contain toxins.",
                CreatedById = user.Id,
            });

            await dbContext.Proposals.AddAsync(new Proposal
            {
                Title = "Reusable Cloth Shopping Bags",
                ShortDescription = "Better alternatives of plastic bags.",
                Description = "Many grocery stores offer the option of paper, plastic or the purchase of their reusable shopping bags. The bags are usually displayed throughout the store, as well as at the customer service counter and the cash register. They come in a variety of colors, perhaps with the company logo, and some are festive for the holidays. They’re usually from a durable inexpensive material or fabric. Some grocery chains ask shoppers to pay for plastic bags. By purchasing an eco-friendly recyclable shopping bag, you’re helping the planet and saving money, too  — as long as you remember to bring them.",
                CreatedById = user.Id,
            });

            await dbContext.Proposals.AddAsync(new Proposal
            {
                Title = "Eco Alternatives to Sponges",
                ShortDescription = "Sustainable Deeds. Plant based cleaning - Alternative to plastic sponges",
                Description = "Did you know that most regular washing up sponges are made from synthetic and plastic fibres, and that each time you use a sponge those fibres are released straight into the water system? What can we do about this issue? As is often the case the natural world has an answer. This time it is in the form of the Luffa Cylindrica plant.This plant, which is part of the cucumber family and native to Asia, is also commonly known as a loofah plant or sponge gourd.Luffah fruits are edible when they are young and as they mature they become more fibrous and suitable for sponge production. When dried and peeled the luffah plant reveals a skeleton that is stiff with a wire like texture, which when hydrated makes for a perfect sponge.",
                CreatedById = user.Id,
            });

            await dbContext.Proposals.AddAsync(new Proposal
            {
                Title = "Cardboard Boxes",
                ShortDescription = "Useful storage!",
                Description = "Ask your store if it has a stash of free cardboard boxes and use one or two to carry your groceries. Some chains have them readily available at checkout so groceries can be packed as they’re checked. They come in all shapes and sizes. Along with being strong and durable, cardboard boxes are recyclable. Whenever you buy something shipped in a cardboard box, reuse it at the grocery store if your local market doesn’t provide free ones for its customers.",
                CreatedById = user.Id,
            });

            await dbContext.Proposals.AddAsync(new Proposal
            {
                Title = "Use LED light bulbs",
                ShortDescription = "Save energy and money!",
                Description = "Not only do LED light bulbs last longer than conventional bulbs, they’re far more efficient too! This means that you’ll be using less power and having to replace your light bulbs less frequently – everyone’s a winner. What's more, they're available in a range of brightness and designs so you can really tailor the lighting to your needs or to suit the room.",
                CreatedById = user.Id,
            });

            await dbContext.Proposals.AddAsync(new Proposal
            {
                Title = "Insulate your home",
                ShortDescription = "Save energy and money!",
                Description = "Homes that aren’t well insulated are much harder to keep warm when it's cold, and cool when the weather is hot. Insulating your home is one of the best eco-friendly tips for your home that we can offer you.",
                CreatedById = user.Id,
            });

            // 8
            await dbContext.Proposals.AddAsync(new Proposal
            {
                Title = "Use eco-friendly cleaning products",
                ShortDescription = "Save money with eco friendly products for cleaning!",
                Description = "A lot of cleaning products have a lot of harmful chemicals in them that aren’t environmentally friendly to create or dispose of. In fact, repeated exposure to these cleaning products can affect your health as well as the environment. Green cleaning products use more natural and organic methods of cleaning which are far less harmful.",
                CreatedById = user.Id,
            });

            await dbContext.Proposals.AddAsync(new Proposal
            {
                Title = "COMPOST YOUR FOOD WASTE",
                ShortDescription = "Compost helps environment.",
                Description = "This does involve worms! Particularly if you don’t have a garden or live in the city without a communal compost area. Take the plunge and build a wormery with a small bucket, used newspaper, and some ‘Red Wrigglers’. There are lots of tips online on how to do it – have a look here. If you do have a garden(even a tiny one) you could try the Bokashi Method.It uses a wheat bran to ‘pickle’ your veg and meat waste.You’ll need a small bin and the bran to get started.",
                CreatedById = user.Id,
            });

            await dbContext.Proposals.AddAsync(new Proposal
            {
                Title = "DITCH USING DISPOSABLE RAZORS",
                ShortDescription = "Great way to save money!",
                Description = "This is one I’m guilty of. And as of writing this I’m going to commit to buying a razor with a replaceable blade. It’s funny the things you just don’t think about. Ultimately, the plastic from disposable razors is going straight to landfill or worse – oceans. This stops now for me and I urge you do the same.",
                CreatedById = user.Id,
            });

            // 11
            await dbContext.Proposals.AddAsync(new Proposal
            {
                Title = "WATER HOUSE PLANTS WITH RAIN WATER",
                ShortDescription = "Great idea for your bills!",
                Description = "Collect it in empty jam or food jars. I also use glasses of water I haven’t finished overnight to water plants.",
                CreatedById = user.Id,
            });

            await dbContext.Proposals.AddAsync(new Proposal
            {
                Title = "Wash Your Clothes In Cold Water",
                ShortDescription = "Up to 90% of the energy used by a washing machine goes toward heating water, according to Energy Star.",
                Description = "Skip the heating and just use your washing machine on the cold water setting. This way, you reduce carbon dioxide emission but you also keep your clothes in top condition for longer, as hot water can deteriorate the fabric and make your colorful clothes less vibrant. Unless you’re dealing with stubborn stains like oil stains, there really isn’t a point in running your washing machine on the hot water setting.If you feel the cold water setting doesn’t do a proper job, you can try the warm setting.Energy - wise it’s still better than using the hot water one, but also more efficient for cleaning than the cold water setting.",
                CreatedById = user.Id,
            });

            await dbContext.Proposals.AddAsync(new Proposal
            {
                Title = "Skip The Dryer When Possible",
                ShortDescription = "Save energy and money!",
                Description = "During sunny and hot months, it’s almost a shame to not line-dry your clothes outside. There is something special about line-drying in the fresh air. Not to mention, your clothes and bedding will last longer if you hang them outside on a drying rack instead of drying them in the dryer. If you don’t have a garden or a backyard where you can line-dry your clothes, you can install a drying rack on your balcony and keep the windows open to allow the sun to dry your clothes faster.",
                CreatedById = user.Id,
            });

            await dbContext.Proposals.AddAsync(new Proposal
            {
                Title = "Use a Programmable Thermostat",
                ShortDescription = "Save energy and money!",
                Description = "Get green by installing a programmable thermostat to monitor your cooling and heating systems. A thermostat can reduce the cost of your utility bill and make your home more eco-friendly at the same time.",
                CreatedById = user.Id,
            });

            await dbContext.Proposals.AddAsync(new Proposal
            {
                Title = "Plant Herbs",
                ShortDescription = "Healthier than ever.",
                Description = "In case you were wondering what to do with the fertilizer, here’s your answer – plant your own herb garden. Herbs don’t take a lot of space. You can plant them in small pots and keep them inside the house, close to a sunny window. The big advantage? You will always have fresh herbs for your favorite dishes.  ",
                CreatedById = user.Id,
            });

            await dbContext.Proposals.AddAsync(new Proposal
            {
                Title = "Be Smarter In The Kitchen",
                ShortDescription = "Check out our ideas!",
                Description = "Many people use the oven to make toast because they think it’s not efficient to buy a toaster. However, the oven uses a significant amount of energy to heat up properly and, if you only plan to cook two slices of bread, it’s not at all efficient to use the oven. The toaster uses less energy and gets the job done faster. Speaking of the oven, check the oven door every time you bake or cook something to be sure the oven door is properly closed. Keeping the oven door open leads to a huge amount of heat loss. If you’re a coffee lover, swap the pod coffee maker for a drip coffee maker.Pod coffee makers are not at all eco - friendly since you have to use pods.The plastic capsules end up piling up in landfills every year.With drip coffee makers, you just need ground coffee. Lastly, make sure you minimize food waste by learning how to meal plan, meal prep, and store food properly.",
                CreatedById = user.Id,
            });

            // 18
            await dbContext.Proposals.AddAsync(new Proposal
            {
                Title = "Reduce Purchases",
                ShortDescription = "Simplify your life as much as possible. Only keep belongings that you use/enjoy on a regular basis. By making the effort to reduce what you own, you will naturally purchase less/create less waste in the future.",
                Description = "In general, think before you buy any product - do you really need it? How did the production of this product impact the environment and what further impacts will there be with the disposal of the product (and associated packaging materials)? When you are thinking about buying something, try the 30-Day Rule -- wait 30 days after the first time you decide you want a product to really make your decision. This will eliminate impulse buying. The free, downloadable Wallet Buddy from The Center for a New American Dream is a great constant reminder to make sustainable purchases (including avoiding unessentials).",
                CreatedById = user.Id,
            });

            // 17
            await dbContext.Proposals.AddAsync(new Proposal
            {
                Title = "Buy a Water Filter",
                ShortDescription = "Filter your water is great way of reducing plastic waste!",
                Description = "Whether you opt for a whole-house, an under the sink, a faucet or a pitcher filter, your home will instantly become more eco-friendly if you stop buying plastic water bottles. A water filter saves time, money, and helps reduce the amount of single-use plastic that ends up in the landfills.",
                CreatedById = user.Id,
            });

            // 19
            await dbContext.Proposals.AddAsync(new Proposal
            {
                Title = "Make Your Own",
                ShortDescription = "Save more by making your own products!",
                Description = "Whenever possible, make your own products to cut down on waste and control the materials used. Here are some great inspirations: pinterest diy projects and apartmenttherapy household cleaning recipes and a great homemade toothpaste recipe.",
                CreatedById = user.Id,
            });

            await dbContext.Proposals.AddAsync(new Proposal
            {
                Title = "Encourage Hotels to Reduce Waste",
                ShortDescription = "Environmentally friendly hotels",
                Description = "When staying at a hotel, motel, or bed and breakfast let the management know that you like to support businesses that adopt environmentally responsible practices (including reducing waste). Give hotels a link to Environmental Solutions for Green Hotels. To locate environmentally friendly hotels, go to TripAdvisor (when searching, select 'Green' from the 'Style' menu option) and/or the Green Hotels Association.",
                CreatedById = user.Id,
            });

            await dbContext.SaveChangesAsync();
        }
    }
}
