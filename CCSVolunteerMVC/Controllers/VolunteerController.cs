using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CCSVolunteerMVC.DAL;
using CCSVolunteerMVC.Models;
using CCSVolunteerMVC.ViewModels;

namespace CCSVolunteerMVC.Controllers
{
    public class VolunteerController : Controller
    {
        private CCSContext db = new CCSContext();

		public ActionResult VolunteerSearch(string searchString)
		{
			var viewModel = new VolunteerSearch();
			var combinedSearchModel = new CombinedSearchViewModel();
			var volunteerViewModel = new VolunteerViewModel(db.Volunteers.ToList(), db.Ethnicities.ToList());
			if (!string.IsNullOrEmpty(searchString))
			{
				viewModel = new VolunteerSearch(searchString, db.Volunteers.ToList());
				var combinedSearchViewModel = new CombinedSearchViewModel(volunteerViewModel, viewModel);
				return View(combinedSearchViewModel);
			}
			return View( new CombinedSearchViewModel());
		}

		public ActionResult Index()
		{
			VolunteerViewModel tempModel = new VolunteerViewModel(db.Volunteers.ToList(), db.Ethnicities.ToList());
			return View(tempModel);
		}

        // GET: Volunteer/Details/5
        public ActionResult Details(int? id)
        {
			List<Volunteer> volunteerList = new List<Volunteer>();
			if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volunteer volunteer = db.Volunteers.Find(id);
            if (volunteer == null)
            {
                return HttpNotFound();
            }
			volunteerList.Add(volunteer);
			VolunteerViewModel tempModel = new VolunteerViewModel(volunteerList, db.Ethnicities.ToList());
            return View(tempModel);
        }

        // GET: Volunteer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Volunteer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "volunteerID,volFirstName,volLastName,volDOB,volPin,volGender,volJoinDate,volsCourtOrdered,ethnicityID,volsClient,volsActive")] Volunteer volunteer)
        {
            if (ModelState.IsValid)
            {
				volunteer.volJoinDate = DateTime.Now.Date;
				volunteer.volsCourtOrdered = 0;
				volunteer.volsClient = 0;
				volunteer.volsActive = 1;
				volunteer.volPin = volunteer.volPin;
				db.Volunteers.Add(volunteer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(volunteer);
        }

        // GET: Volunteer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volunteer volunteer = db.Volunteers.Find(id);
            if (volunteer == null)
            {
                return HttpNotFound();
            }
            return View(volunteer);
        }

        // POST: Volunteer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "volunteerID,volFirstName,volLastName,volDOB,volPin,volGender,volJoinDate,volsCourtOrdered,ethnicityID,volsClient,volsActive")] Volunteer volunteer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(volunteer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(volunteer);
        }

        // GET: Volunteer/Delete/5
        public ActionResult Delete(int? id)
        {
			List<Volunteer> volunteerList = new List<Volunteer>();
			if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volunteer volunteer = db.Volunteers.Find(id);
            if (volunteer == null)
            {
                return HttpNotFound();
            }
			volunteerList.Add(volunteer);
			VolunteerViewModel tempModel = new VolunteerViewModel(volunteerList, db.Ethnicities.ToList());
			return View(tempModel);
        }

        // POST: Volunteer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Volunteer volunteer = db.Volunteers.Find(id);
            db.Volunteers.Remove(volunteer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
