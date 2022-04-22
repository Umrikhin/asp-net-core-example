using authorization.Infrastructure;
using authorization.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace authorization.Controllers
{
    public class HomeController : Controller
    {
        private IApartmentsRepository repositoryApartments;
        private IUsersPortalRepository repositoryUsers;

        public HomeController(IApartmentsRepository repoApartments, IUsersPortalRepository repoUsersPortal)
        {
            this.repositoryApartments = repoApartments;
            this.repositoryUsers = repoUsersPortal;
        }

        [AuthorizationFilter]
        public IActionResult Index()
        {
            return View(repositoryApartments.Apartments);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        [Route("captcha-image-login")]
        public IActionResult GetCaptchaImage()
        {
            var captchaCode = GenerateRandomCode();
            CaptchaImage ci = new CaptchaImage(captchaCode, 200, 50, "Century Schoolbook");
            HttpContext.Session.SetString("CaptchaCodeLogin", captchaCode);
            Stream s = new MemoryStream();
            ci.Image.Save(s, ImageFormat.Jpeg);
            ci.Dispose();
            s.Position = 0;
            return new FileStreamResult(s, "image/jpeg");
        }

        private Random random = new Random();

        private string GenerateRandomCode()
        {
            string s = "";
            for (int i = 0; i < 6; i++)
                s = string.Concat(s, this.random.Next(10).ToString());
            return s;
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("User");
            DeleteCookie();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Login(LoginUser login)
        {
            if (HttpContext.Session.GetString("CaptchaCodeLogin") == null)
            {
                ModelState.AddModelError("", "The session has ended. Please try again using the new security code.");
                return View("Login", login);
            }

            if (ModelState.IsValid)
            {
                if (login.CaptchaCode != HttpContext.Session.GetString("CaptchaCodeLogin"))
                {
                    ModelState.AddModelError("", "Error code: Try again!");
                    return View("Login", login);
                }

                try
                {
                    var users = repositoryUsers.UsersPortal;

                    if (users.Where(x => x.UserName == login.User && x.Password == login.Password).Count() > 0)
                    {
                        HttpContext.Session.SetString("User", login.User);
                        SaveCookie(login.User);

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "The user does not exist. Login not possible!");
                        return View("Login", login);
                    }
                }
                catch (Exception err)
                {
                    ModelState.AddModelError("", err.Message);
                    return View("Login", login);
                }
            }
            else
            {
                return View("Login", login);
            }
        }

        private void SaveCookie(string User)
        {
            try
            {
                if (!Request.Cookies.ContainsKey("LoginNameAuthorization"))
                {
                    //Create Cookie
                    CookieOptions option = new CookieOptions();
                    option.Expires = DateTime.Now.AddDays(3);
                    Response.Cookies.Append("LoginNameAuthorization", User, option);
                }
            }
            catch
            {
                
            }
        }

        private void DeleteCookie()
        {
            try
            {
                //Remove Cookie
                Response.Cookies.Delete("LoginNameAuthorization");
            }
            catch
            {

            }
        }
    }
}
