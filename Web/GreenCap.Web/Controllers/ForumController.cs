namespace GreenCap.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ForumController : BaseController
    {
        public IActionResult Latest()
        {
            return this.View();
        }

        public IActionResult Categories()
        {
            return this.View();
        }

        public IActionResult Create()
        {
            return this.View();
        }
    }
}
