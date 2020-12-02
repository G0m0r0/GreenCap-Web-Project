namespace GreenCap.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class EventsController : BaseController
    {
        public IActionResult All()
        {
            return this.View();
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }
    }
}
