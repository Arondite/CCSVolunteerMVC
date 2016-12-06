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
	/// <summary>
	/// The main controller that handles the data and views passed between the
	/// view of the Kiosk application
	/// </summary>
    public class KioskController : Controller
    {
		private CCSContext db = new CCSContext();
		/// <summary>
		/// View where Admin selects which location they are at
		/// </summary>
		/// <returns>The view with two locations</returns>
		public ActionResult LocationSelection()
		{
			return View();
		}
		// GET: Kiosk
		/// <summary>
		/// This is whether the user is clocking in or out
		/// </summary>
		/// <returns>The view with two buttons to choose their selection</returns>
		public ActionResult Index()
        {
            return View();
        }
		/// <summary>
		/// This is the screen whether they are a volunteer or a group
		/// </summary>
		/// <param name="clock">Whether they are clocking in or out</param>
		/// <returns>A view with two buttons to choose their affiliation</returns>
		public ActionResult VolunteerGroup(string clock)
		{
			List<string> tempCollection = new List<string>();
			if (!string.IsNullOrWhiteSpace(clock))
			{
				tempCollection.Add(clock);
			}
			return View(tempCollection);
		}
		/// <summary>
		/// This is the view where a volunteer enters their pin to login
		/// </summary>
		/// <param name="action">The action helps keep track whether they are clockin in or out</param>
		/// <returns>A view where they enter the pin</returns>
		public ActionResult VolunteerClock(string action)
		{
			VolunteerClockModel volunteerClockModel = new VolunteerClockModel(db.Volunteers.ToList(), action);
			return View(volunteerClockModel);
		}
		/// <summary>
		/// This is the list of groups that are stored into the database. Tabs navigate alphabetically
		/// </summary>
		/// <param name="alphabetChar">The starting index of the group search</param>
		/// <returns>A view listing all of the groups that are associated with the character</returns>
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
		/// <summary>
		/// This shows the details of the group that the group chose
		/// It allows them to choose how many volunteers are with them and what position
		/// </summary>
		/// <param name="id">The Id of the group</param>
		/// <returns>A view associated with the id</returns>
		public ActionResult GroupLogin(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			VolunteerGroup volunteerGroup = db.VolunteerGroups.Find(id);
			VolunteerGroupPositionViewModel volunteerPositionViewModel = new VolunteerGroupPositionViewModel(volunteerGroup, db.Positions.ToList());
			if (volunteerGroup == null)
			{
				return HttpNotFound();
			}
			return View(volunteerPositionViewModel);
		}
		/// <summary>
		/// This is a list of volunteers that is associated with the pin that was punched
		/// in on the VolunteerClock view
		/// </summary>
		/// <param name="password">This is the pin being passed in</param>
		/// <returns>A view with a list of volunteers that is associated with the given pin</returns>
		public ActionResult VolunteerPasswordList(int? password)
		{
			VolunteerViewModel volunteerViewModel = new VolunteerViewModel(db.Volunteers.ToList(), db.Ethnicities.ToList());
			return View(volunteerViewModel);
		}
		/// <summary>
		/// This is the details of the selected volunteer that the user has chosen
		/// This allows them to select what position that they are volunteering for
		/// </summary>
		/// <param name="id">The id associated with the selected user</param>
		/// <returns>A view that has details of the user and allows the to submit thier record and position</returns>
		public ActionResult VolunteerDetails(int? id)
		{
			IEnumerable<Volunteer> volunteer = new List<Volunteer>();
			volunteer = db.Volunteers.Where(v => v.volunteerID == id).ToList();
			VolunteerViewModel volunteerViewModel = new VolunteerViewModel(volunteer, db.Ethnicities.ToList());
			VolunteerPositionViewModel volunteerPositionViewModel = new VolunteerPositionViewModel(volunteerViewModel, db.Positions.ToList());
			return View(volunteerPositionViewModel);
		}
		public ActionResult NewVolunteer()
		{
			return View();
		}

		// POST: Volunteer/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult NewVolunteer([Bind(Include = "volunteerID,volFirstName,volLastName,volDOB,volGender,ethnicityID")] Volunteer volunteer)
		{
			/*volPin,*/
			/*volJoinDate,volsCourtOrdered,*/
			/*,volsClient,volsActive*/
			if (ModelState.IsValid)
			{
				volunteer.volJoinDate = DateTime.Now.Date;
				volunteer.volsCourtOrdered = 0;
				volunteer.volsClient = 0;
				volunteer.volsActive = 1;
				volunteer.volPin = volunteer.volPin;
				db.Volunteers.Add(volunteer);
				db.SaveChanges();
				return RedirectToAction("VolunteerDetails", new { id = volunteer.volunteerID});
			}

			return View(volunteer);
		}
		/// <summary>
		/// This is a login screen where the Admin must put their username and password
		/// to clock out the Kiosk. If correct input, it will clock everyone out that forgot to 
		/// clock out with a given one hour default time.
		/// </summary>
		/// <returns></returns>
		public ActionResult KioskExit()
		{
			return View();
		}
	}
}