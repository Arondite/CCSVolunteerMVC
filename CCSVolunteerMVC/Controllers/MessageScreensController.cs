using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCSVolunteerMVC.Controllers
{
    public class MessageScreensController : Controller
    {
        // GET: MessageScreens
        public ActionResult Index()
        {
            return View();
        }
		public ActionResult CompleteSignIn()
		{
			return View();
		}
		public ActionResult CompleteSignOut()
		{
			return View();
		}
		public ActionResult CourtOrderedScreen()
		{
			return View();
		}
		public ActionResult NoRecords()
		{
			return View();
		}
		public ActionResult EndTerminal()
		{
			return View();
		}
    }
}