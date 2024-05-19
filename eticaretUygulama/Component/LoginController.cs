using Microsoft.AspNetCore.Mvc;

namespace eticaretUygulama.Component
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
