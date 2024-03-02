using Limakaz.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Limakaz.Controllers.Client;
public class HomeController : Controller
{
    public readonly LimakDbContext _limakDbContext;

    public HomeController(LimakDbContext limakDbContext)
    {
        _limakDbContext = limakDbContext;
    }

    [HttpGet]
    public ViewResult Index()
    { 
        return View();
    }

}
