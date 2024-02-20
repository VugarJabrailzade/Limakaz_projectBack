using Limakaz.Database;
using Limakaz.Database.DomainModels;
using Limakaz.Migrations;
using Limakaz.ViewModels.Officies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace Limakaz.Controllers.Admin
{
    [Route("admin/officies")]
    public class OfficiesController : Controller
    {
        public readonly LimakDbContext _limakDbContext;
        public readonly ILogger<OfficiesController> _logger;

        public OfficiesController(LimakDbContext limakDbContext, ILogger<OfficiesController> logger)
        {
            _limakDbContext = limakDbContext;
            _logger = logger;
        }

        [HttpGet("list", Name ="officies")]
        public IActionResult Officies()
        {
            var officies = _limakDbContext.Officies.OrderBy(o=>o.Id).ToList();

            return View("Views/Admin/Officies/Officies.cshtml", officies);
        }

        #region Add Office

        [HttpGet("add", Name="add-list")]
        public IActionResult Add()
        {
            return View("Views/Admin/Officies/AddOffice.cshtml");

        }

        

        [HttpPost("add", Name ="add-office")]
        public IActionResult Add(OfficiesResponseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            if (model == null)
            {
                ModelState.AddModelError("Name", "Can't be null");
                return BadRequest(new { message = "Can't be null" });
            }

            var existOffice = _limakDbContext.Officies.FirstOrDefault(x => x.Name == model.Name);
            if (existOffice != null)
            {
                return BadRequest();

            }

            var officeAdd = new Officies
            {
                Name = model.Name,
                Location = model.Location,
                WorkingDays = model.WorkingDays,
                OpeningTime = model.OpeningTime,
                ClosetingTime = model.ClosetingTime,
            };

            _limakDbContext.Officies.Add(officeAdd);
            _limakDbContext.SaveChanges();


            return RedirectToAction("Officies");

        }

        #endregion

        #region Update Office
        [HttpGet("update", Name="update-office-list")]
        public async Task<IActionResult> Update(int id)
        {
            var office = await _limakDbContext.Officies.FirstOrDefaultAsync(x=> x.Id == id);
            if (office == null)  return BadRequest(ModelState);

            var officeModel = new OfficiesRequestViewModel
            {
                Id = office.Id,
                Name = office.Name,
                Location = office.Location,
                WorkingDays = office.WorkingDays,
                OpeningTime = office.OpeningTime,
                ClosetingTime = office.ClosetingTime,
            };

            return View("Views/Admin/Officies/UpdateOffice.cshtml", officeModel);
        }

        [HttpPost("update", Name ="update-office-post")]
        public async Task<IActionResult> Update([FromQuery] int id, OfficiesRequestViewModel model)
        {
            if (!ModelState.IsValid) { return BadRequest(); }

            var newOffice = new Officies
            {
                Id = model.Id,
                Name = model.Name,
                Location = model.Location,
                WorkingDays = model.WorkingDays,
                OpeningTime = model.OpeningTime,
                ClosetingTime = model.ClosetingTime,
            };

            _limakDbContext.Officies.Update(newOffice);
            _limakDbContext.SaveChanges();

            return RedirectToAction("Officies");

        }

        #endregion

        [HttpGet("delete", Name ="delete-office")]
        public async Task<IActionResult> Delete(int id)
        {
            Officies officies = await _limakDbContext.Officies.FirstOrDefaultAsync(p=> p.Id == id);
            if (officies == null)
            {
                return NotFound();
            }

            _limakDbContext.Remove(officies);
            _limakDbContext.SaveChangesAsync();

            return RedirectToAction("Officies");

        }
        
    }
}
