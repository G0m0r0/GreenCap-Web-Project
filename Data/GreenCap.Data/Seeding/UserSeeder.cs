namespace GreenCap.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using GreenCap.Data.Models;
    using Microsoft.EntityFrameworkCore.Internal;

    public class UserSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Users.Any())
            {
                return;
            }

            await dbContext.Users.AddAsync(new ApplicationUser
            {
                Id = "1",
                UserName = "Admin",
                Email = "Admin@email.com",
                PasswordHash = "123",
            });
        }
    }
}
