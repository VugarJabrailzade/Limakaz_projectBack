using BCrypt.Net;
using Limakaz.Database;
using Limakaz.Database.DomainModels;
using Limakaz.Exceptions;
using Limakaz.Services.Abstract;
using Limakaz.ViewModels.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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
        public async Task<IActionResult> Login()
        {
            return ViewComponent("Login");
        }

        [HttpPost("login", Name ="login-post")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = _limakDbContext.Users.Include(x=> x.Officies).
              Include(x => x.UserRole).
              FirstOrDefault(x => x.Email == model.Email);

            if (user == null)
            {
                //ModelState.AddModelError("Email", "Email or Password is wrong!");
                //return View();
                return RedirectToRoute("user-register");
            }

            if (!BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
            {
                ModelState.AddModelError("Email", "Email or Password is wrong!");
                return View();
            }


            var claims = new List<Claim>()
            {
                new Claim("Id", user.Id.ToString())
            };

            //foreach (var userRole in user.UserRole)
            //{

            //    claims.Add(new Claim(ClaimTypes.Role, userRole.Role.ToString()));
            //}



            var claimsIdentity = new ClaimsIdentity(claims, "Cookie");
            var claimsPricipal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync("Cookie", claimsPricipal);

            return View("Views/Auth/UserPanel.cshtml");
        }

        [HttpGet("register", Name ="user-register")]
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

        [HttpPost("log", Name ="logout")]
        public async Task<IActionResult> Logout(LogoutViewModel model)
        {
            if(model.AcceptLogout == true)
            {
              await HttpContext.SignOutAsync("Cookie");

            }
            else
            {
                return View("Views/Auth/UserPanel.cshtml");
            }

            return View("Views/Home/Index.cshtml");
        }


    }

    
}
