namespace GreenCap.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using GreenCap.Common;
    using GreenCap.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public class UserSeeder : ISeeder
    {
        public static async Task SeedAdminAsync(UserManager<ApplicationUser> userManager)
        {
            var admin = await userManager.FindByEmailAsync(GlobalConstants.AdministratorEmail);

            if (admin != null)
            {
                return;
            }

            var user = new ApplicationUser
            {
                UserName = GlobalConstants.AdministratorEmail,
                Email = GlobalConstants.AdministratorEmail,
            };

            await userManager.CreateAsync(user, GlobalConstants.AdministratorPassword);
            await userManager.AddToRoleAsync(user, GlobalConstants.AdministratorRoleName);
        }

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            await SeedAdminAsync(userManager);
        }
    }
}
