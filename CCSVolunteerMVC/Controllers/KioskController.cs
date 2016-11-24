using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CCSVolunteerMVC.DAL;
using CCSVolunteerMVC.Models;
using CCSVolunteerMVC.ViewModels;
using System.Net;

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

		public ActionResult VolunteerGroup(string clock)
		{
			List<string> tempCollection = new List<string>();
			if (!string.IsNullOrWhiteSpace(clock))
			{
				tempCollection.Add(clock);
			}
			return View(tempCollection);
		}

		public ActionResult VolunteerClock(string action)
		{
			VolunteerClockModel volunteerClockModel = new VolunteerClockModel(db.Volunteers.ToList(), action);
			return View(volunteerClockModel);
		}
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
					groupList = (db.VolunteerGroups.Where(g => g.volGrpName.IndexOf(item) == 0).ToList());
				}
			}
			return View(groupList);
		}
		public ActionResult GroupLogin(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			VolunteerGroup volunteerGroup = db.VolunteerGroups.Find(id);
			if (volunteerGroup == null)
			{
				return HttpNotFound();
			}
			return View(volunteerGroup);
		}
		public ActionResult VolunteerPasswordList(int? password)
		{
			VolunteerViewModel volunteerViewModel = new VolunteerViewModel(db.Volunteers.ToList(), db.Ethnicities.ToList());
			return View(volunteerViewModel);
		}
		public ActionResult VolunteerDetails(int? id)
		{
			IEnumerable<Volunteer> volunteer = new List<Volunteer>();
			volunteer = db.Volunteers.Where(v => v.volunteerID == id).ToList();
			VolunteerViewModel volunteerViewModel = new VolunteerViewModel(volunteer, db.Ethnicities.ToList());
			return View(volunteerViewModel);
		}
		public ActionResult KioskExit()
		{
			return View();
		}
	}
}