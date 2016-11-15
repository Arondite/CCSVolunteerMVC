using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CCSVolunteerMVC.DAL;

namespace CCSVolunteerMVC.Controllers
{
    public class KioskController : Controller
    {
        // GET: Kiosk
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult VolunteerGroup()
		{
			return View();
		}

		public ActionResult VolunteerPin()
		{
			return View();
		}

		public ActionResult VolunteerClock()
		{
			var db = new CCSContext();
			return View();
		}
    }
}