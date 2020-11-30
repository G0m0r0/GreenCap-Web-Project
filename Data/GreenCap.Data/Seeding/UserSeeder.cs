namespace GreenCap.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using GreenCap.Common;
    using GreenCap.Data.Models;

    public class UserSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Users.Any(x => x.Email == GlobalConstants.AdministratorEmail))
            {
                return;
            }

            await dbContext.Users.AddAsync(new ApplicationUser
            {
                Email = GlobalConstants.AdministratorEmail,
                PasswordHash = "AQAAAAEAACcQAAAAEKkutl9vhu94KUBRtm1JMUiazYxLtFNyizHhKLJRBeMMkFD/IX41z6K1OpdUMRb5QA==",
                NormalizedEmail = GlobalConstants.AdministratorEmail.ToUpper(),
                UserName = GlobalConstants.AdministatorName,
                NormalizedUserName = GlobalConstants.AdministatorName.ToUpper(),
            });
        }
    }
}
