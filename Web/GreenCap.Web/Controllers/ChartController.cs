namespace GreenCap.Web.Controllers
{
    using System.Threading.Tasks;

    using GreenCap.Services.Data.Contracts;
    using GreenCap.Web.ViewModels.OutputViewModel;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class ChartController : BaseController
    {
        private readonly IChartService charService;

        public ChartController(IChartService charService)
        {
            this.charService = charService;
        }

        [HttpGet]
        public async Task<ActionResult<ChartResponseModel>> GetActivity()
        {
            var montlyActivity = await this.charService.GetMonthsActivity();

            var monthlyActivirtyModel = new ChartResponseModel
            {
                MonthsActivity = montlyActivity,
            };

            return monthlyActivirtyModel;
        }
    }
}
