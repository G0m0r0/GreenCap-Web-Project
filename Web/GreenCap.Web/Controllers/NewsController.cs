namespace GreenCap.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class NewsController : Controller
    {
        public IActionResult All()
        {
            return this.View();
        }
    }
}
