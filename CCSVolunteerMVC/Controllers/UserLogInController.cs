using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCSVolunteerMVC.Controllers
{
    public class UserLogInController : Controller
    {
        // GET: UserLogIn
        public ActionResult Index()
        {
            return View();
        }
		public ActionResult AdminIntro()
		{
			return View();
		}
	}
}