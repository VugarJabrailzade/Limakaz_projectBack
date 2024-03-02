using BCrypt.Net;
using Limakaz.Database;
using Limakaz.Database.DomainModels;
using Limakaz.Services.Abstract;
using Limakaz.ViewModels.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Limakaz.Controllers.Client
{
    public class AuthController : Controller
    {
        public readonly LimakDbContext _limakDbContext;
        public readonly IRegisterService _registerService;

        public AuthController(LimakDbContext limakDbContext, IRegisterService registerService)
        {
            _limakDbContext = limakDbContext;
            _registerService = registerService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return ViewComponent("Login");
        }
        [HttpPost("login", Name ="login-post")]
        public IActionResult Login(LoginViewModel model)
        {
             return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            var offices = _limakDbContext.Officies.ToList();

            if (offices != null)
            {
                var model = new RegisterViewModel
                {
                    Officies = offices
                };
                return View(model);
            }
            else
            {
                
                return NotFound("boş.");
            }
        }

        [HttpPost("register", Name ="user-register-post")]
        public IActionResult Register(RegisterResponseViewModel model)
        {

            if(!ModelState.IsValid)
            {
                // ModelState içindeki hataları kontrol et
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        var errorMessage = error.ErrorMessage;
                        // Hata mesajlarını kullanarak gerekli işlemleri yapabilirsiniz.
                    }
                }

                model.RulesAccepted = true;

                // ModelState.IsValid false olduğunda yapılacak işlemler
                var registerViewModel = new RegisterViewModel
                {
                    Officies = _limakDbContext.Officies.ToList(),
                };

                return View(registerViewModel);
            }


            if (_limakDbContext.Users.Any(x => x.Email == model.Email))
            {
                var registerViewModel = new RegisterViewModel
                {
                    Officies = _limakDbContext.Officies.ToList()
                };

                ModelState.AddModelError("Email", "Email already taken");
                return View(registerViewModel);
            }
            
            if(model.Password != model.ConfirmPassword)
            {
                var registerViewModel = new RegisterViewModel
                {
                    Officies = _limakDbContext.Officies.ToList()
                };

                return View(registerViewModel);
            }
            

            var fullPhoneNum = model.PhonePrefix + model.PhoneNumber;

            var user = new User
            {
                Name = model.Name,
                PersonType = model.PersonType,
                CustomerCode = _registerService.GenerateCustomerCode(),
                Surname = model.Surname,
                Email = model.Email,
                PhoneNumber = fullPhoneNum,
                Password = BCrypt.Net.BCrypt.HashPassword(model.Password),
                OfficeId = model.OfficeId,
                NotificationType = model.NotificationType,
                Nationality = model.Nationality,
                SerialNumber = model.SerialNumber,
                BirthdayDate = model.BirthdayDate.ToUniversalTime(),
                Gender = model.Gender,
                FinCode = model.FinCode,
                Address = model.Address,
                RulesAccepted = model.RulesAccepted
                
            };

             _limakDbContext.Users.Add(user);
            _limakDbContext.SaveChanges(); 

            return View("Views/Auth/UserPanel.cshtml");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("Cookie");

            return View("Views/Home/Index");
        }


    }

    
}
