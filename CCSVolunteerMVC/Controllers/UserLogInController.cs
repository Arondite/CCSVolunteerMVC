using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCSVolunteerMVC.Controllers
{
	/// <summary>
	/// A controller for the UserLogIn Views
	/// </summary>
    public class UserLogInController : Controller
    {
        // GET: UserLogIn
		/// <summary>
		/// This is the login page for the Admin
		/// </summary>
		/// <returns>A view that allows for a login</returns>
        public ActionResult Index()
        {
            return View();
        }
		/// <summary>
		/// This is a view that shows a couple of actions that the Admin can use to 
		/// handle the data in the database
		/// </summary>
		/// <returns>A view with listed posibilities of the admin</returns>
		public ActionResult AdminIntro()
		{
			return View();
		}
	}
}