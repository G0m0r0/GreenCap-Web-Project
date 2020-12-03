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
        [HttpPost]
        public IActionResult Create()
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }


            return this.View();
        }
    }
}
