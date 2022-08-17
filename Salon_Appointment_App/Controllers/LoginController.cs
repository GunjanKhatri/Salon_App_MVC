using Salon_Appointment_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Salon_Appointment_App.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login()
        {
            string username = Request["username"];
            string password = Request["password"];
            using (SalonAppEntities salon = new SalonAppEntities())
            {

                bool IsValidUser = salon.Users
                   .Any(u => u.Username.ToLower() == username.ToLower() && u
                   .Password == password);

                if (IsValidUser)
                {
                    Session["UserName"] = username;
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index","Login");
        }
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Register(User registerUser)
        {
            using (SalonAppEntities salon = new SalonAppEntities())
            {
                salon.Users.Add(registerUser);
                salon.SaveChanges();
                return RedirectToAction("Index", "Login");

            }
            
        }
        public ActionResult Logout()
        {
            Session["UserName"] = null;
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}