namespace GreenCap.Services.Data.Contracts
{
    using GreenCap.Services.Data.DTOs;

    public interface IHomeService
    {
        // 1. Use the view model
        // 2. Create DTO -> view model
        // 3. Typles(,,,)
        HomeStatisticsDto GetCounts();
    }
}
