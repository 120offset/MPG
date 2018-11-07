using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MPG.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "If you ever start taking things too seriously, just remember that we are talking monkeys on an organic spaceship flying through the universe - Joe Rogan ";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact me Anytime";

            return View();
        }
    }
}