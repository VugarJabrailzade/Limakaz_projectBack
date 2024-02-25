using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Limakaz.Controllers.Client;

public class HomeController : Controller
{
    [HttpGet]
    public ViewResult Index()
    {
        return View();
    }

    
}
