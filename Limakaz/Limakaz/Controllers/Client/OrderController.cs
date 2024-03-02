using Microsoft.AspNetCore.Mvc;

namespace Limakaz.Controllers.Client
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
