using Microsoft.AspNetCore.Mvc;

namespace CI_Platform.Controllers
{
    public class UserController : Controller
    {
        public IActionResult LoginPage()
        {
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        public IActionResult ResetPassword()
        {
            return View();
        }

        public IActionResult RegistrationPage()
        {
            return View();
        }
    }
}
