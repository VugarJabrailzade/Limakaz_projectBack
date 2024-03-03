using Limakaz.ViewModels.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Limakaz.ViewComponents
{
    public class LoginViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
       {   // Giriş formu veya giriş bağlantısı
            var model =  new LoginViewModel();
            return View(model);
        }
    }
}
