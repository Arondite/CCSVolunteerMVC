using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCSVolunteerMVC.Controllers
{
	/// <summary>
	/// Controller for the MessageScreens Views
	/// </summary>
    public class MessageScreensController : Controller
    {
        // GET: MessageScreens
		/// <summary>
		/// Not used in the current application
		/// </summary>
		/// <returns>Not applicable</returns>
        public ActionResult Index()
        {
            return View();
        }
		/// <summary>
		/// This is a screen that tells the user that they successfully logged in
		/// </summary>
		/// <returns>A view displaying the info</returns>
		public ActionResult CompleteSignIn()
		{
			return View();
		}
		/// <summary>
		/// This returns a screen that tells the user that they successfully logged out
		/// </summary>
		/// <returns>A view displaying the info</returns>
		public ActionResult CompleteSignOut()
		{
			return View();
		}
		/// <summary>
		/// This is a screen that tells the user that they have to talk to an adminstration to clock out
		/// </summary>
		/// <returns>A view displaying the info</returns>
		public ActionResult CourtOrderedScreen()
		{
			return View();
		}
		/// <summary>
		/// This is a screen that tells the user that they cannot clock out because there is not a record
		/// of them clocked in in the application
		/// </summary>
		/// <returns>A view displaying the info</returns>
		public ActionResult NoRecords()
		{
			return View();
		}
		/// <summary>
		/// This tells the administrator that they have successfully stopped the kiosk terminal
		/// </summary>
		/// <returns>A view displaying the info</returns>
		public ActionResult EndTerminal()
		{
			return View();
		}
    }
}