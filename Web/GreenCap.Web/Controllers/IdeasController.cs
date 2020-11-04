namespace GreenCap.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class IdeasController : BaseController
    {
        public IActionResult All()
        {
            return this.View();
        }

        public IActionResult Create()
        {
            return this.View();
        }
    }
}
