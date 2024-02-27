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
        var list = _limakDbContext.Tariffs.Include(p=> p.Country).
                   OrderBy(v=> v.Id).ToList();

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

    [HttpGet("update", Name ="update-tariff")]
    public IActionResult Update([FromQuery]int id)
    {
        Tariff tariff = _limakDbContext.Tariffs.FirstOrDefault(p=> p.Id == id);

        if (tariff == null) return BadRequest(ModelState);

        var model = new TariffUpdateViewModel
        {
            Id = tariff.Id,
            Weight = tariff.Weight,
            PriceAzn = tariff.PriceAzn,
            PriceUsd = tariff.PriceUsd,
            CountryId = tariff.CountryId,
            Country = _limakDbContext.Countries.ToList()
         
        };

        return View("Views/Admin/Tariff/UpdateTariff.cshtml", model);
    }

    [HttpPost("update", Name ="update-tariff-post")]
    public IActionResult Update(TariffUpdateRequestViewModel model)
    {
        if (!ModelState.IsValid) return RedirectToAction("Tariff");

        if(model.CountryId != null)
        {
            var country =  _limakDbContext.Countries.FirstOrDefault(p=> p.Id == model.CountryId.Value);
            if (country == null) return BadRequest();
        }

        Tariff tariff = _limakDbContext.Tariffs.FirstOrDefault(x=> x.Id == model.Id);
        if (tariff == null) return NotFound();

        try
        {
            tariff.Weight = model.Weight;
            tariff.PriceAzn = model.PriceAzn;
            tariff.PriceUsd = model.PriceUsd;
            tariff.CountryId = model.CountryId;
            
            _limakDbContext.Tariffs.Update(tariff);
            _limakDbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception("Not Found");
        }

        return RedirectToAction("Tariff");
    }

    [HttpGet("delete", Name ="delete-tariff")]
    public async  Task<IActionResult> Delete(int id)
    {
        Tariff tariff = await _limakDbContext.Tariffs.FirstOrDefaultAsync(x => x.Id == id);

        if(tariff == null) return NotFound();

        _limakDbContext.Remove(tariff);
        _limakDbContext.SaveChangesAsync();

        return RedirectToAction("Tariff");
    }
}
