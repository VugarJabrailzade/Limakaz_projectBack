using Limakaz.Database;
using Limakaz.Database.DomainModels;
using Limakaz.ViewModels.AbroadAddresses;
using Limakaz.ViewModels.Officies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Limakaz.Controllers.Admin
{
    [Route("admin/abroadaddressTr")]
    public class AbroadAddressTrController : Controller
    {
        public readonly LimakDbContext _limakDbContext;
        public readonly ILogger<AbroadAddressTrController> _logger;

        public AbroadAddressTrController(LimakDbContext limakDbContext, ILogger<AbroadAddressTrController> logger)
        {
            _limakDbContext = limakDbContext;
            _logger = logger;
        }

        [HttpGet("list", Name = "abroad-address-tr")]
        public IActionResult Address()
        {
            var address = _limakDbContext.AbdroadAddressTr.ToList();

            return View("Views/Admin/AbroadAddressTr/Address.cshtml", address);
        }

        #region Add Tr Address

        [HttpGet("add", Name = "add-abroad-address-tr")]
        public IActionResult Add()
        {
            return View("Views/Admin/AbroadAddressTr/AddAddressTr.cshtml");
        }

        [HttpPost("add", Name ="add-abroad-address-post-tr")]
        public IActionResult Add(TrAddressResponseViewModel model)
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

            var existOffice = _limakDbContext.AbdroadAddressTr.FirstOrDefault(x => x.Id == model.Id);
            if (existOffice != null)
            {
                return BadRequest();

            }

            var addressAddtr = new AbroadAddressTr
            {
                Country = model.Country,
                City = model.City,
                Region = model.Region,
                Address = model.Address,
                WorkingDays = model.WorkingDays,
                WorkingHours = model.WorkingHours,
                PostalCode = model.PostalCode,
                PassportCode = model.PassportCode,
                TaxNumber = model.TaxNumber,
                PhoneNumber = model.PhoneNumber
            };

            _limakDbContext.AbdroadAddressTr.Add(addressAddtr);
            _limakDbContext.SaveChanges();


            return RedirectToAction("Address");
        }

        #endregion

        #region Update Tr Address

        [HttpGet("update", Name="update-address-tr-list")]
        public async Task<IActionResult> Update([FromQuery] int id)
        {

            var address = await _limakDbContext.AbdroadAddressTr.FirstOrDefaultAsync(x => x.Id == id);
            if (address == null) return BadRequest(ModelState);

            var addressModel = new TrAddressRequestViewModel
            {
                Country = address.Country,
                City = address.City,
                Region = address.Region,
                Address = address.Address,
                WorkingDays = address.WorkingDays,
                WorkingHours = address.WorkingHours,
                PostalCode = address.PostalCode,
                PassportCode = address.PassportCode,
                TaxNumber = address.TaxNumber,
                PhoneNumber = address.PhoneNumber
            };

            return View("Views/Admin/AbroadAddressTr/UpdateAddressTr.cshtml", addressModel);
        }

        [HttpPost("update", Name ="update-address-tr-post")]
        public IActionResult Update([FromQuery] int id,TrAddressRequestViewModel model)
        {
            if (!ModelState.IsValid) { return BadRequest(); }

            var newAddress = new AbroadAddressTr
            {
                Id = model.Id,
                Country = model.Country,
                City = model.City,
                Region = model.Region,
                Address = model.Address,
                WorkingDays = model.WorkingDays,
                WorkingHours = model.WorkingHours,
                PostalCode = model.PostalCode,
                PassportCode = model.PassportCode,
                TaxNumber = model.TaxNumber,
                PhoneNumber = model.PhoneNumber
            };

            _limakDbContext.AbdroadAddressTr.Update(newAddress);
            _limakDbContext.SaveChanges();

            return RedirectToAction("Address");
        }

        #endregion

        [HttpGet("delete", Name ="delete-address-tr")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            if (!ModelState.IsValid) return NotFound();

            AbroadAddressTr addressTr = await _limakDbContext.AbdroadAddressTr.FirstOrDefaultAsync(x=> x.Id == id);
            if (addressTr == null) return BadRequest();

            _limakDbContext.Remove(addressTr);
            _limakDbContext.SaveChangesAsync();

            return RedirectToAction("Address");

        }
    }
}
