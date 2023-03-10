
using MainProjectsEntity.Data;
using MainProjectsEntity.Models;
using MainProjectsEntity.ViewModel;
using MainProjectsEntity.Sessions;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using System.Net.Mail;

namespace CI_Platform.Controllers

{
    public class UserController : Controller
    {



        private readonly CI_PlatformContext _db;
        private readonly IHttpContextAccessor _context;

        public UserController(CI_PlatformContext db, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _context = httpContextAccessor;
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
            //ViewBag.Token = token;  
            return View();
        }

        public IActionResult RegistrationPage()
        {
            return View();
        }

        public IActionResult PlatformLandingPage(string searchString,string sortby, string Id, int pg = 1)
        {

            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("LoginPage");
            }
            else
            {
                string userid = Id;
                long uid = Convert.ToInt64(userid);
                var user = _db.Users.Where(c => c.UserId == uid).FirstOrDefault();
                if (user != null)
                {
                    HttpContext.Session.SetString("Fullname" ,user.FirstName + " "+user.LastName);
                    //HttpContext.Session.SetString("Avatar", user.Avatar);
                }


                if (pg < 0)
                {
                    pg = pg;
                }

                const int pageSize = 3;
                var missions = MissionCards();
                int recsSkip = (pg - 1) * pageSize;
                if (!string.IsNullOrEmpty(searchString))
                {
                    return View(searchString);
                }
                else
                {



                    int recsCount = missions.Count();
                    var pager = new Pager(recsCount, pg, pageSize);
                    var data = missions.Skip(recsSkip).Take(pager.PageSize).ToList();
                    this.ViewBag.Pager = pager;


                    ViewBag.sortvalue = "Sort by";
                    if (sortby != null)
                    {
                        ViewBag.sortvalue = sortby;
                        if (sortby == "Newest")
                        {
                            var sortdata = missions.OrderByDescending(x => x.CreatedAt).ToList();
                            int recsCount1 = sortdata.Count();
                            var pager1 = new Pager(recsCount, pg, pageSize);
                            var data1 = sortdata.Skip(recsSkip).Take(pager.PageSize).ToList();
                            this.ViewBag.Pager = pager1;
                            return View(data1);
                        }
                        else if (sortby == "Oldest")
                        {
                            var sortdata = missions.OrderBy(x => x.CreatedAt).ToList();
                            int recsCount1 = sortdata.Count();
                            var pager1 = new Pager(recsCount, pg, pageSize);
                            var data1 = sortdata.Skip(recsSkip).Take(pager.PageSize).ToList();
                            this.ViewBag.Pager = pager1;
                            return View(data1);
                        }
                        else if (sortby == "Lowest available seats")
                        {
                            var sortdata = missions.OrderBy(x => x.Availability).ToList();
                            int recsCount1 = sortdata.Count();
                            var pager1 = new Pager(recsCount, pg, pageSize);
                            var data1 = sortdata.Skip(recsSkip).Take(pager.PageSize).ToList();
                            this.ViewBag.Pager = pager1;
                            return View(data1);
                        }
                        else if (sortby == "Highest available seats")
                        {
                            var sortdata = missions.OrderByDescending(x => x.Availability).ToList();
                            int recsCount1 = sortdata.Count();
                            var pager1 = new Pager(recsCount, pg, pageSize);
                            var data1 = sortdata.Skip(recsSkip).Take(pager.PageSize).ToList();
                            this.ViewBag.Pager = pager1;
                            return View(data1);
                        }
                        else if (sortby == "My favourites")
                        {
                            var sortdata = missions.FirstOrDefault(x => x.FavoriteMissions.Count > 0);
                            return View(sortdata);
                        }
                        else if (sortby == "Registration deadline")
                        {
                            var sortdata = missions.OrderByDescending(x => x.EndDate).ToList();
                            int recsCount1 = sortdata.Count();
                            var pager1 = new Pager(recsCount, pg, pageSize);
                            var data1 = sortdata.Skip(recsSkip).Take(pager.PageSize).ToList();
                            this.ViewBag.Pager = pager1;
                            return View(data1);
                        }
                    }

                    return View(data);



                }

                

                //List<MissionCard> list = MissionCards();
                //return View(list);

            }
        }





        public List<MissionCard> MissionCards()
        {

            


            using (var db = _db)
            {
                var missions = (from a in _db.Missions
                                join b in _db.Cities on a.CityId equals b.CityId
                                join c in _db.MissionThemes on a.ThemeId equals c.MissionThemeId
                                join d in _db.GoalMissions on a.MissionId equals d.MissionId into temp
                                from d in temp.DefaultIfEmpty()
                                select new MissionCard
                                {
                                    Title = a.Title,
                                    ShortDescription = a.ShortDescription,
                                    Description = a.Description,
                                    StartDate = a.StartDate,
                                    EndDate = a.EndDate,
                                    CityName = b.Name,
                                    Theme = c.Title,
                                    GoalObjectiveText = d.GoalObjectiveText,
                                    OrganizationName = a.OrganizationName,
                                    Availability = a.Availability,
                                    CreatedAt = a.CreatedAt,
                                    MissionId = a.MissionId
                                }).ToList();
                return missions;
            }
        }





        public IActionResult VolunteeringMissionPage()
        {
            return View();
        }

        public IActionResult VolunteeringStoryListingPage()
        {
            return View();
        }





        public JsonResult Country()
        {
            var cnt = _db.Countries.ToList();
            return new JsonResult(cnt);
        }

        public JsonResult City(int countryId)
        {
            var ct = _db.Cities.Where(a => a.Country.CountryId == countryId).ToList();
            return new JsonResult(ct);
        }


        public JsonResult Themes()
        {
            var theme = _db.MissionThemes.ToList();
            return new JsonResult(theme);
        }
        
        public JsonResult Skills()
        {
            var skill = _db.Skills.ToList();
            return new JsonResult(skill);
        }





        #region User Login-and-Authentication

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LoginPage(User obj, string Email, string Password)
        {
            if (!ModelState.IsValid)
            {

                var verify = _db.Users.Where(a => a.Email == obj.Email && a.Password == obj.Password).ToList().Count();

                if (verify == 1)
                {

                    var user = _db.Users.Where(c => c.Email == obj.Email).FirstOrDefault();

                    HttpContext.Session.SetString("Email", obj.Email);
                    return RedirectToAction("PlatformLandingPage", "User", new { @Id = user.UserId });
                }

                else if (verify == 0)
                {
                    TempData["Usernotfound"] = "User Not Found or Invalid Crediantials \"PLEASE ENTER CORRECT DETAILS\"";
                }

                else
                {
                    TempData["Usererror"] = "Error in login";
                    return View();
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
                if (check != 0)
                {

                    try
                    {

                        string token = Guid.NewGuid().ToString();
                        string email = obj.Email;
                        var link = Url.ActionLink("ResetPassword", "User", new { token });


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

                        var passreset = new PasswordReset
                        {
                            Email = email,
                            Token = token
                        };
                        _db.PasswordResets.Add(passreset);
                        _db.SaveChanges();

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
            if (ModelState.IsValid)
            {
                _db.Users.Add(obj);
                _db.SaveChanges();
                TempData["Registered"] = "User Register Successfully";
            }
            else
            {
                TempData["Registeredfail"] = "User Registration Failed Please try again!!";
            }
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ResetPasswordPost()
        {
            if (ModelState.IsValid)
            {

                //var chngeflag = _db.PasswordResets.ToList();
                string newpass = HttpContext.Request.Form["NewPass"];   //by naming the input field of new-password
                var currenturl = HttpContext.Request.Headers.Referer.ToString();    // getting the url into string from link
                var currenttoken = currenturl.Split("=")[1];    //for seperating the tokken from url 
                Console.WriteLine(currenttoken);     // just for displaying tokken
                var mail = _db.PasswordResets.Where(a => a.Token == currenttoken).OrderByDescending(p => p.CreatedAt).First();
                //var match = _db.PasswordResets.Where(a => a.Token == currenttoken && a.Token != chngeflag. && a.CreatedAt.AddHours(4) > DateTime.Now).ToList().Count();
                var match = _db.PasswordResets.Where(a => a.Token == currenttoken && a.ResetFlag == false && a.CreatedAt.AddHours(4) > DateTime.Now).ToList().Count();  // Conditions for link ex:Active till 4 hrs
                if (match > 0)
                {
                    var user = _db.Users.Where(x => x.Email == mail.Email).ToList().First();
                    var cnfrm = _db.Users.Where(a => a.Email == mail.Email).ToList().Count();   // to chek the mail for creating the new password for correct email 
                    if (cnfrm > 0)
                    {
                        user.Password = newpass;
                        mail.ResetFlag = true;

                        _db.Users.Update(user);
                        _db.PasswordResets.Update(mail);
                        _db.SaveChanges();

                        TempData["Resetsuccess"] = "User-Password Reset Success, LOGIN WITH NEW PASSWORD!!";
                    }
                }
                else
                {
                    TempData["Resetfail"] = "User-Password Reset Failed Please try again!!";
                }
            }
            return RedirectToAction("LoginPage");


        }

        #endregion


        #region session

        public ActionResult Logout()
        {
            HttpContext.Session.Remove("Email");
            return RedirectToAction("LoginPage");
        }

        #endregion


        #region MissionDatafetch

    
        #endregion
    }
}
