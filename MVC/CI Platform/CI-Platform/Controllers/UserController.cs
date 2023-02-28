
using MainProjectsEntity.Data;
using MainProjectsEntity.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

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
            if (!ModelState.IsValid)
            {
                //System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

                //string mail = HttpContext.Request.Form["f-email"];

                var check = _db.Users.Where(a => a.Email == obj.Email).ToList().Count();
                if(check != 0)
                {
                    try
                    {
                        MailMessage newMail = new MailMessage();
                        // use the Gmail SMTP Host
                        SmtpClient client = new SmtpClient("smtp.gmail.com");

                        // Follow the RFS 5321 Email Standard
                        newMail.From = new MailAddress("andrew.boyle@ethereal.email", "andrew");

                        newMail.To.Add("ravipateljigneshpatel137@gmai.com");// declare the email subject

                        newMail.Subject = "Passwoed Change Link and Options"; // use HTML for the email body

                        newMail.IsBodyHtml = true; newMail.Body = "<h1> This is my first Templated Email in C# </h1>";

                        // enable SSL for encryption across channels
                        client.EnableSsl = true;
                        // Port 465 for SSL communication
                        client.Port = 465;
                        // Provide authentication information with Gmail SMTP server to authenticate your sender account
                        client.Credentials = new System.Net.NetworkCredential("andrew.boyle@ethereal.email", "FmCRRHgf4h8v12jc8y");

                        client.Send(newMail); // Send the constructed mail
                        Console.WriteLine("Email Sent to registered email");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error -" + ex);
                        TempData["Exception"] = ex.ToString();
                    }
                }
                else
                {
                        TempData["Emailerror"] = "Error in Sending Email Please check and enter correct email";
                }

            }
            return RedirectToAction("ForgotPassword","User");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegistrationPage(User obj)
        {
            _db.Users.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("LoginPage","User");
        }


    }
}
