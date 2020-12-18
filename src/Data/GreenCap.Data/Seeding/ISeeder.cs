namespace GreenCap.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    public interface ISeeder
    {
        Task SeedAsync(IDeletableRepository dbContext, IServiceProvider serviceProvider);
    }
}
