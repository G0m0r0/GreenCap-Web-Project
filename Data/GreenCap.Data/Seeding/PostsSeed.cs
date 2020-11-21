namespace GreenCap.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using GreenCap.Data.Models;
    using GreenCap.Data.Models.Enums;

    public class PostsSeed : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.Posts.Where(x => x.Category == Category.General).Any())
            {
                await dbContext.Posts.AddAsync(new Post
                {
                    ProblemTitle = "What problems forums solve?",
                    Description = "Organize information - It creates a central place for discussions to take place, which can be organized into categories and topics. Everything can easily be searched, permissions can be assigned, etc.",
                    Category = Category.General,
                    CreatedById = "1",
                });

                await dbContext.Posts.AddAsync(new Post
                {
                    ProblemTitle = "Professional psychotherapist",
                    Description = "I have moderated forums in the past and any forums must have direction and be closely supervised, not always easy to get it right especially sorting out arguments trolls and spammers and keeping the community secure at the same time.",
                    Category = Category.General,
                    CreatedById = "1",
                });
            }

            if (!dbContext.Posts.Where(x => x.Category == Category.Ecology).Any())
            {
                await dbContext.Posts.AddAsync(new Post
                {
                    ProblemTitle = "Jelly mushroom",
                    Description = " It is a variety of jelly mushroom, which is in golden color , The name of this species is : Dacryopinax spathularia",
                    Category = Category.Ecology,
                    CreatedById = "1",
                });
            }

            if (!dbContext.Posts.Where(x => x.Category == Category.Environment).Any())
            {
                await dbContext.Posts.AddAsync(new Post
                {
                    ProblemTitle = "What's the longest food chain?",
                    Description = "Since food chains can be as long as you want them to be, I am wondering what is the longest 'natural' food chain. Also, I don't want humans to be counted in as they are omnivores and can interfere in any part of the food chain! What is the longest food chain known to man?",
                    Category = Category.Environment,
                    CreatedById = "1",
                });

                await dbContext.Posts.AddAsync(new Post
                {
                    ProblemTitle = "5G technology",
                    Description = " am beginning to hear rumors of how 5G technology in cell phones and other tech will result in all sorts of death and destruction or at least kill off birds or may just give your ears a suntan. Is there any truth to these rumors ? ",
                    Category = Category.Environment,
                    CreatedById = "1",
                });
            }

            if (!dbContext.Posts.Where(x => x.Category == Category.Exercise).Any())
            {
                await dbContext.Posts.AddAsync(new Post
                {
                    ProblemTitle = "Workout Plan",
                    Description = "Hello everyone. I'm currently on a long path to lose weight. I weigh 309 and want to get down to 165. I started at 327 and since I have been going to the gym I've lost 18 lbs. I have a nutritionist now and I have the diet portion covered. Now comes my dilemma. I'm afraid of hitting a plateau. Monday - biceps/back Tuesday - abdominals/glutes Wednesday - chest/tris/shoulders Thursday - legs/glutes Friday - biceps/back Saturday - chest/tris/shoulder Sunday - rest",
                    Category = Category.Exercise,
                    CreatedById = "1",
                });

                await dbContext.Posts.AddAsync(new Post
                {
                    ProblemTitle = "Diet while working out",
                    Description = "I started running and completed 30 miles this month just jogging at around 15 min/mile .I havent made any drastic changes this month in terms of diet. While tracking my weight over the last month, I see some stretch marks have appeared, but no significant weight loss or change in body shape. So How important is diet while working out?? I am not sure if I can really maintain a caloric deficit to lose weight. Or is it too early to see visible changes in the body?? I weigh around 200 lbs and 6'1.",
                    Category = Category.Exercise,
                    CreatedById = "1",
                });
            }
        }
    }
}
