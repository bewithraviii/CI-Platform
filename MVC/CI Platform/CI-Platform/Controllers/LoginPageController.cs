using Microsoft.AspNetCore.Mvc;

namespace CI_Platform.Controllers
{
    public class LoginPageController : Controller
    {
        public IActionResult LoginPage()
        {
            return View();
        }
    }
}
