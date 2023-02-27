
using MainProjectsEntity.Data;
using MainProjectsEntity.Models;
using Microsoft.AspNetCore.Mvc;

namespace CI_Platform.Controllers
{
    public class UserController : Controller
    {



        private readonly CI_PlatformContext _db;
        public UserController(CI_PlatformContext db)
        {
            _db = db;
        }



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

        public IActionResult PlatformLandingPage()
        {
            return View();
        }
        public IActionResult VolunteeringMissionPage()
        {
            return View();
        }

        public IActionResult VolunteeringStoryListingPage()
        {
            return View();
        }







        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LoginPage(User obj)
        {
            if (!ModelState.IsValid)
            {

            
            var verify = _db.Users.Where(a => a.Email == obj.Email && a.Password == obj.Password).ToList().Count();

            if (verify == 1)
            {
                return RedirectToAction("PlatformLandingPage", "User");
            }

            else if (verify == 0)
            {
                TempData["Usernotfound"] = "User Not Found";
            }
            else
            {
                TempData["Usererror"] = "Error in login";
            }

            }
            return View(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ForgotPassword(User obj)
        {

            return View();
        }


    }
}
