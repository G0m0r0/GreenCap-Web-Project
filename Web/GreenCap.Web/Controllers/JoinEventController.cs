namespace GreenCap.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class JoinEventController : BaseController
    {
        public JoinEventController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
