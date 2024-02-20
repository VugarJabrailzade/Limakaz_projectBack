using Limakaz.Database;
using Limakaz.Database.DomainModels;
using Limakaz.ViewModels.AbroadAddresses;
using Limakaz.ViewModels.Officies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Limakaz.Controllers.Admin
{
    [Route("admin/abroadaddressUs")]
    public class AbroadAddressUsController : Controller
    {
        public readonly LimakDbContext _limakDbContext;
        public readonly ILogger<AbroadAddressUsController> _logger;

        public AbroadAddressUsController(LimakDbContext limakDbContext, ILogger<AbroadAddressUsController> logger)
        {
            _limakDbContext = limakDbContext;
            _logger = logger;
        }

        [HttpGet("list", Name="abroad-address-us")]
        public IActionResult Address()
        {
            var address = _limakDbContext.AbdroadAddressUs.ToList();

            return View("Views/Admin/AbroadAddressUs/AddressUs.cshtml", address);
        }

        #region Abroad Address Add for US

        [HttpGet("add", Name ="add-abroad-address-us")]
        public IActionResult Add()
        {
            return View("Views/Admin/AbroadAddressUs/AddAddressUs.cshtml");
        }

        [HttpPost("add", Name ="add-abroad-address-us-post")]
        public IActionResult Add(UsAddressResponseViewModel model)
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

            var existOffice = _limakDbContext.AbdroadAddressUs.FirstOrDefault(x => x.Id == model.Id);
            if (existOffice != null)
            {
                return BadRequest();

            }

            var addressAddus = new AbroadAddressUs
            {
                Country = model.Country,
                City = model.City,
                State = model.State,
                AddressLine = model.AddressLine,
                WorkingDays = model.WorkingDays,
                WorkingHours = model.WorkingHours,
                ZipCode = model.ZipCode,
                PhoneNumber = model.PhoneNumber
            };

            _limakDbContext.AbdroadAddressUs.Add(addressAddus);
            _limakDbContext.SaveChanges();


            return RedirectToAction("Address");
        }

        #endregion

        #region Update Abroad Address Us

        [HttpGet("update",Name ="update-abroad-address-us")]
        public async Task<IActionResult> Update([FromQuery] int id)
        {
            var address = await _limakDbContext.AbdroadAddressUs.FirstOrDefaultAsync(x => x.Id == id);
            if (address == null) return BadRequest(ModelState);

            var addressModel = new UsAddressRequestViewModel
            {
                Id = address.Id,
                Country = address.Country,
                City = address.City,
                State = address.State,
                AddressLine = address.AddressLine,
                WorkingDays = address.WorkingDays,
                WorkingHours = address.WorkingHours,
                ZipCode = address.ZipCode,
                PhoneNumber = address.PhoneNumber
                
            };

            return View("Views/Admin/AbroadAddressUs/UpdateAddressUs.cshtml", addressModel);
        }

        [HttpPost("update", Name ="update-abroad-address-us-post")]
        public IActionResult Update([FromQuery] int id, UsAddressRequestViewModel model)
        {

            if (!ModelState.IsValid) { return BadRequest(); }

            var newAddress = new AbroadAddressUs
            {
                Id = model.Id,
                Country = model.Country,
                City = model.City,
                State = model.State,
                AddressLine = model.AddressLine,
                WorkingDays = model.WorkingDays,
                WorkingHours = model.WorkingHours,
                ZipCode = model.ZipCode,
                PhoneNumber = model.PhoneNumber
            };

            _limakDbContext.AbdroadAddressUs.Update(newAddress);
            _limakDbContext.SaveChanges();

            return RedirectToAction("Address");
        }

        #endregion

        [HttpGet("delete", Name = "delete-address-us")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            if (!ModelState.IsValid) return NotFound();

            AbroadAddressUs addressUs = await _limakDbContext.AbdroadAddressUs.FirstOrDefaultAsync(x => x.Id == id);
            if (addressUs == null) return BadRequest();

            _limakDbContext.Remove(addressUs);
            _limakDbContext.SaveChangesAsync();

            return RedirectToAction("Address");

        }
    
    }
}
