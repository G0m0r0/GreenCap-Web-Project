namespace GreenCap.Services.Data
{
    using GreenCap.Services.Data.DTOs;

    public interface IHomeStatistics
    {
        // 1. Use the view model
        // 2. Create DTO -> view model
        // 3. Typles(,,,)
        HomeStatisticsDTO GetCounts();
    }
}
