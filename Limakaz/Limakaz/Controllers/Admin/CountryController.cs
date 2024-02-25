using Limakaz.Database;
using Limakaz.Database.DomainModelsı;
using Limakaz.ViewModels.Country;
using Limakaz.ViewModels.OrderStatus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Limakaz.Controllers.Admin
{
    [Route("admin/ordercountries")]
    public class CountryController : Controller
    {
        public readonly LimakDbContext _limakDbContext;
        public readonly ILogger<CountryController> _logger;

        public CountryController(LimakDbContext limakDbContext, ILogger<CountryController> logger)
        {
            _limakDbContext = limakDbContext;
            _logger = logger;
        }

        [HttpGet("list", Name ="countries-list")]
        public IActionResult Country()
        {
            var list = _limakDbContext.Countries.ToList();

            return View("Views/Admin/Country/Countries.cshtml", list);
        }

        #region Country Add

        [HttpGet("add", Name = "add-country")]
        public IActionResult Add()
        {
            return View("Views/Admin/Country/AddCountry.cshtml");
        }

        [HttpPost("add", Name = "add-country-post")]
        public IActionResult Add(CountriesRequestViewModel model)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (model == null) return NoContent();

            var existCountry = _limakDbContext.OrderStatus.FirstOrDefault(x => x.Id == model.Id);
            if (existCountry != null)
            {
                return BadRequest();

            }

            var countryAdd = new Country
            {
                Id = model.Id,
                Name = model.Name,
                CountryPrefix = model.CountryPrefix,
                IsActive = model.IsActive
            };

            _limakDbContext.Countries.Add(countryAdd);
            _limakDbContext.SaveChanges();

            return RedirectToAction("Country");
        }

        #endregion

        #region Update Country

        [HttpGet("update", Name = "update-country")]
        public async Task<IActionResult> Update([FromQuery] int id)
        {
            var country = await _limakDbContext.Countries.FirstOrDefaultAsync(x => x.Id == id);
            if (country == null) return BadRequest(ModelState);

            var countryModel = new CountriesRequestViewModel
            {
                Id = country.Id,
                Name = country.Name,
                CountryPrefix = country.CountryPrefix,
                IsActive = country.IsActive

            };

            return View("Views/Admin/Country/UpdateCountries.cshtml", countryModel);
        }

        [HttpPost("update", Name = "update-countries-post")]
        public async Task<IActionResult> Update([FromQuery] int id, CountriesRequestViewModel model)
        {
            if (!ModelState.IsValid) { return BadRequest(); }

            var newCountry = new Country
            {
                Id = model.Id,
                Name = model.Name,
                CountryPrefix = model.CountryPrefix,
                IsActive = model.IsActive
            };

            _limakDbContext.Countries.Update(newCountry);
            _limakDbContext.SaveChanges();

            return RedirectToAction("Country");

        }

        #endregion

        [HttpGet("delete", Name = "delete-country")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            Country country = await _limakDbContext.Countries.FirstOrDefaultAsync(p => p.Id == id);
            if (country == null)
            {
                return NotFound();
            }

            _limakDbContext.Remove(country);
            _limakDbContext.SaveChangesAsync();

            return RedirectToAction("Country");

        }
    }
}
