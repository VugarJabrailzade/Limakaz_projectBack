using Microsoft.AspNetCore.Mvc;

namespace Limakaz.Controllers.Client;

[Route("calculator")]
public class CalculatorController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}
