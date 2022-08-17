using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Salon_Appointment_App.Controllers
{
    
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Services()
        {
            ViewBag.Message = "Your services page.";

            return View();
        }

        public ActionResult BookNow()
        {
            ViewBag.Message = "Your booking page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Haircut()
        {
            ViewBag.Message = "Your haircut page.";

            return View();
        }
    }
}