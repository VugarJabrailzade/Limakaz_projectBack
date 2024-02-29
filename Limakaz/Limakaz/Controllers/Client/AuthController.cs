using Limakaz.Database;
using Limakaz.Database.DomainModels;
using Limakaz.ViewModels.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Limakaz.Controllers.Client
{
    public class AuthController : Controller
    {
        public readonly LimakDbContext _limakDbContext;

        public AuthController(LimakDbContext limakDbContext)
        {
            _limakDbContext = limakDbContext;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("register", Name ="user-register-post")]
        public IActionResult Register(RegisterViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            if (_limakDbContext.Users.Any(x => x.Email == model.Email))
            {
                ModelState.AddModelError("Email", "Email already taken");
                return View();
            }

            var user = new User
            {
                Name = model.Name,
                PersonType = model.PersonType,
                Surname = model.Surname,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Password = model.Password,
                OfficeId = model.OfficeId,
                NotificationType = model.NotificationType,
                Nationality = model.Nationality,
                SerialNumber = model.SerialNumber,
                BirthdayDate = model.BirthdayDate,
                Gender = model.Gender,
                FinCode = model.FinCode,
                Address = model.Address,
            };

             _limakDbContext.Users.Add(user);
            _limakDbContext.SaveChanges(); 

            return RedirectToAction("UserPanel");
        }

        [HttpGet]
        public IActionResult UserPanel()
        {
            return View();
        }
    }

    
}
