using Microsoft.AspNetCore.Mvc;

namespace Limakaz.Controllers.Client
{
    [Route("user-setting")]
    public class UserSettingController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
