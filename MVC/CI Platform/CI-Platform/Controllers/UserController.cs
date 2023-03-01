
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

            //System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;


            if (!ModelState.IsValid)
            {
                var check = _db.Users.Where(a => a.Email == obj.Email).ToList().Count();
                if(check != 0)
                {
                
                    try
                    {
                        
                        string token = Guid.NewGuid().ToString();
                        string email = obj.Email;
                        var link = Url.ActionLink("ResetPassword", "User", new {token});


                        MailMessage newMail = new MailMessage();
                        // use the Gmail SMTP Host
                        SmtpClient client = new SmtpClient("smtp.gmail.com");

                        // Follow the RFS 5321 Email Standard
                        newMail.From = new MailAddress("dummypatel137@gmail.com", "Dummy Patel");

                        newMail.To.Add("ravipateljigneshpatel137@gmail.com");// declare the email subject newMail.To.Add("obj.Email");

                        newMail.Subject = "Password Change Link and Options"; // use HTML for the email body

                        newMail.IsBodyHtml = true; newMail.Body = "<h1> This is my first Templated Email which will provide you Email link for  </h1><br>" + link;

                        // enable SSL for encryption across channels
                        client.EnableSsl = true;
                        // Port 587 for SSL communication
                        client.Port = 587;
                        // Provide authentication information with Gmail SMTP server to authenticate your sender account
                        client.Credentials = new System.Net.NetworkCredential("dummypatel137@gmail.com", "wfepiqtslzxwklwo");

                        client.Send(newMail); // Send the constructed mail
                        Console.WriteLine("Email Sent to registered email");

                         TempData["Emailsent"] = "Reset-Password Link is sent to provided E-mail please check and create New-Password";

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error -" + ex);
                        TempData["Exception"] = ex.ToString();
                    }
                    
                }
                else
                {
                        TempData["Emailerror"] = "Error in sending email please check and enter correct email";
                }
            }
            return View();
            

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegistrationPage(User obj)
        {
            if (!ModelState.IsValid)
            {
                _db.Users.Add(obj);
                _db.SaveChanges();
                TempData["Registered"] = "User Register Successfully";
            }
            return View();
        }



        public IActionResult ResetPassword(User obj)
        {

            _db.Users.Add(obj);
            _db.SaveChanges(true);
            return View();
        }


    }
}
