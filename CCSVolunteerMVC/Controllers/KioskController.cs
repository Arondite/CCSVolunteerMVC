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
		private CCSContext db = new CCSContext();
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
			return View(db.Volunteers.ToList());
		}
    }
}