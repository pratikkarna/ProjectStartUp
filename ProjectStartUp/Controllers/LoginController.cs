using Microsoft.AspNetCore.Mvc;

namespace ProjectStartUp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
