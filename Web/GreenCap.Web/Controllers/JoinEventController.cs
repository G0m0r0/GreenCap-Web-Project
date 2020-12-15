using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenCap.Web.Controllers
{
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
