namespace GreenCap.Services.Data.Contracts
{
    using System.Threading.Tasks;

    public interface IChartService
    {
         Task<int[]> GetMonthsActivity();
    }
}
