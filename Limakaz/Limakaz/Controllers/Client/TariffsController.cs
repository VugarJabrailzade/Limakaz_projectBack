using Limakaz.Database;
using Limakaz.ViewModels.Tariff;
using Microsoft.AspNetCore.Mvc;

namespace Limakaz.Controllers.Client;

[Route("tariffs")]
public class TariffsController : Controller
{
    public readonly LimakDbContext _limakDbContext;

    public TariffsController(LimakDbContext limakDbContext)
    {
        _limakDbContext = limakDbContext;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var tariff = _limakDbContext.Tariffs.ToList();
        var offices = _limakDbContext.Officies.ToList();
        var combinedModel = new CombinedTariffViewModel { Officies = offices, Tariffs = tariff };

        return View(combinedModel);
    }
}
