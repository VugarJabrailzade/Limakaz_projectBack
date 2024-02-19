using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Limakaz.Controllers.Client
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        
    }
}
