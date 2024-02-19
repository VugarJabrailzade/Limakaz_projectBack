using Limakaz.Database;
using Limakaz.Database.DomainModels;
using Limakaz.Migrations;
using Limakaz.ViewModels.Officies;
using Microsoft.AspNetCore.Mvc;

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
            var officies = _limakDbContext.Officies.ToList();

            return View("Views/Admin/Officies/Officies.cshtml", officies);
        }

        [HttpGet("add")]
        public IActionResult Add()
        {
            //if (!ModelState.IsValid)
            //{
            //    return NotFound();
            //}
            //if (model == null)
            //{
            //    ModelState.AddModelError("Name", "Can't be null");
            //    return BadRequest(new { message = "Can't be null" });
            //}

            //var existOffice = _limakDbContext.Officies.FirstOrDefault(x => x.Name == model.Name);
            //if (existOffice != null)
            //{
            //    return BadRequest();

            //}

            //var officeAdd = new Officies
            //{
            //    Name = model.Name,
            //    Location = model.Location,
            //    OpeningTime = model.OpeningTime,
            //    ClosetingTime = model.ClosetingTime,
            //};

            //_limakDbContext.Officies.Add(officeAdd);
            //_limakDbContext.SaveChanges();
            var officies = _limakDbContext.Officies.ToList();


            return View("Views/Admin/Officies/AddOffice.cshtml", officies);

        }
    }
}
