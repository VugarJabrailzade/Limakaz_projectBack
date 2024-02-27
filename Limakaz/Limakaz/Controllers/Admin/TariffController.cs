using Limakaz.Database;
using Limakaz.Database.DomainModels;
using Limakaz.ViewModels.Tariff;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Limakaz.Controllers.Admin;

[Route("admin/tariffs")]
public class TariffController : Controller
{
    public readonly LimakDbContext _limakDbContext;
    public readonly ILogger<TariffController> _logger;



    public TariffController(ILogger<TariffController> logger, LimakDbContext limakDbContext)
    {
        _logger = logger;
        _limakDbContext = limakDbContext;
    }

    [HttpGet("list", Name ="tariff-list")]
    public IActionResult Tariff()
    {
        var list = _limakDbContext.Tariffs.Include(p=> p.Country).ToList();

        return View("Views/Admin/Tariff/Tariffs.cshtml", list);
    }

    [HttpGet("add", Name = "add-tariff")]
    public IActionResult Add()
    {
        var model = new TariffResponseViewModel
        {
            Country = _limakDbContext.Countries.ToList(),
        };

        return View("Views/Admin/Tariff/AddTariff.cshtml", model);
    }

    [HttpPost("add", Name = "add-tariff-post")]
    public IActionResult Add(TariffRequestViewModel model)
    {
        if (model == null) return BadRequest(ModelState);

        if (!ModelState.IsValid) return BadRequest();

        if(model.CountryId != null)
        {
            var country = _limakDbContext.Countries.FirstOrDefault(c => c.Id == model.CountryId.Value);
            if (country == null)
            {
                ModelState.AddModelError("CategoryId", "Category doesn't exist");

                return View("Views/Admin/Tariff/Tariffs.cshtml");
            }
        }


        try
        {
            var tariff = new Tariff
            {
                Id = model.Id,
                Weight = model.Weight,
                PriceAzn = model.PriceAzn,
                PriceUsd = model.PriceUsd,
                CountryId = model.CountryId
            };

            _limakDbContext.Tariffs.Add(tariff);
            _limakDbContext.SaveChanges();

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Postgresql Exception");

            throw ex;
        }


        return RedirectToAction("Tariff");
    }
}
