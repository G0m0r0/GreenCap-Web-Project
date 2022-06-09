namespace GreenCap.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IChartService
    {
        Task<List<int>> GetMonthsActivity();
    }
}
