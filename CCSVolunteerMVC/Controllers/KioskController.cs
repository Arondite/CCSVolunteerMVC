using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CCSVolunteerMVC.DAL;
using CCSVolunteerMVC.Models;

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

		//public ActionResult GroupClock()
		//{
		//	return View();
		//}
		public ActionResult GroupClock(char? alphabetChar)
		{
			List<VolunteerGroup> groupList = new List<VolunteerGroup>();
			if (alphabetChar == null)
			{
				alphabetChar = 'A';
			}
			string alphabetString = alphabetChar.ToString();
			string[] alphabet = { "A", "B", "C","D","E","F","G","H","I","J","K", "L",
						"M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};
			foreach (var item in alphabet)
			{
				if (item == alphabetString)
				{
					groupList = (db.VolunteerGroups.Where(g => g.volGrpName.Contains(item)).ToList());
				}
			}
			return View(groupList);
		}
    }
}