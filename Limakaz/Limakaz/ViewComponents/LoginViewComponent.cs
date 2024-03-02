using Microsoft.AspNetCore.Mvc;

namespace Limakaz.ViewComponents
{
    public class LoginViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {   // Giriş formu veya giriş bağlantısı
                return View();
        }
    }
}
