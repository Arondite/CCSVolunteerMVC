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
	public class HoursWorkedController : Controller
	{
		private CCSContext db = new CCSContext();

		public ActionResult TotalHours(DateTime? startDate, DateTime? endDate)
		{
			if (startDate == null)
			{
				DateTime firstOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

				startDate = firstOfMonth;
			}
			if (endDate == null)
			{
				endDate = DateTime.Today;
			}

			var listOfWorkDates = new List<WorkDate>();

			var dayQuerySingle = db.HoursWorkeds
				.Where(r => DbFunctions.TruncateTime(r.hrsWrkedSchedDate) >= startDate && DbFunctions.TruncateTime(r.hrsWrkedSchedDate) <= endDate)
				.Include(i => i.positionLocation)
			.GroupBy(group => new
			{
				group.hrsWrkedSchedDate
				//group.positionLocation.position
			})
			.Select(r => new WorkDate
			{
				day = r.Key.hrsWrkedSchedDate,
				individualHoursOgden = r.Where(q => q.volunteerID != null && q.positionLocationID == 2).Sum(t => t.hrsWrkdQty),
				individualHoursSaltLake = r.Where(q => q.volunteerID != null && q.positionLocationID == 1).Sum(t => t.hrsWrkdQty),
				groupHoursOgden = r.Where(q => q.volunteerID == null && q.positionLocationID == 2).Sum(t => t.hrsWrkdQty),
				groupHoursSaltLake = r.Where(q => q.volunteerID == null && q.positionLocationID == 1).Sum(t => t.hrsWrkdQty),
				startingDate = (DateTime)DbFunctions.TruncateTime(startDate),
				endingDate = (DateTime)DbFunctions.TruncateTime(endDate)
			}).ToList();

			return View(dayQuerySingle);
		}

		public ActionResult HoursByDayDetail(DateTime? QueryDate)
		{
			if (QueryDate == null)
			{
				QueryDate = DateTime.Today;
			}

			var query = db.HoursWorkeds
				.Where(r => DbFunctions.TruncateTime(r.hrsWrkedSchedDate) == QueryDate)
				.Include(s => s.volunteer)
				.Include(s => s.volunterGroup)
				.OrderBy(r => r.volunteer.volLastName)
				.OrderBy(r => r.volunterGroup.volGrpName)
				.Select(r => new HoursByDayDetailViewModel
				{
					hoursWorkedTimeIn = r.hrsWrkdTimeIn,
					hoursWorkedTimeOut = r.hrsWrkdTimeOut,
					hoursWrkedQty = r.hrsWrkdQty,
					volunteerGroupName = r.volunteerGroupID == null ? "N/A" : r.volunterGroup.volGrpName,
					volFirstName = r.volunteerID == null ? "N/A" : r.volunteer.volFirstName,
					volLastName = r.volunteerID == null ? "N/A" : r.volunteer.volLastName,
					date = (DateTime)DbFunctions.TruncateTime(QueryDate)

				});

			return View(query.ToList());


		}


		// GET: HoursWorked
		public ActionResult Index()
		{
			return View(db.HoursWorkeds.ToList());
		}

		// GET: HoursWorked/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			HoursWorked hoursWorked = db.HoursWorkeds.Find(id);
			if (hoursWorked == null)
			{
				return HttpNotFound();
			}
			return View(hoursWorked);
		}

		// GET: HoursWorked/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: HoursWorked/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "hoursWorkedID,positionLocationID,hrsWrkdIDType,hrsWrkdTimeIn,hrsWrkdTimeOut,userAcctID,modifiedOn,hrsWrkedSchedDate,volunteerID,volunteerGroupID,hrsWrkdQty")] HoursWorked hoursWorked)
		{
			if (ModelState.IsValid)
			{
				db.HoursWorkeds.Add(hoursWorked);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(hoursWorked);
		}

		// GET: HoursWorked/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			HoursWorked hoursWorked = db.HoursWorkeds.Find(id);
			if (hoursWorked == null)
			{
				return HttpNotFound();
			}
			return View(hoursWorked);
		}

		// POST: HoursWorked/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "hoursWorkedID,positionLocationID,hrsWrkdIDType,hrsWrkdTimeIn,hrsWrkdTimeOut,userAcctID,modifiedOn,hrsWrkedSchedDate,volunteerID,volunteerGroupID,hrsWrkdQty")] HoursWorked hoursWorked)
		{
			if (ModelState.IsValid)
			{
				db.Entry(hoursWorked).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(hoursWorked);
		}

		// GET: HoursWorked/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			HoursWorked hoursWorked = db.HoursWorkeds.Find(id);
			if (hoursWorked == null)
			{
				return HttpNotFound();
			}
			return View(hoursWorked);
		}

		// POST: HoursWorked/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			HoursWorked hoursWorked = db.HoursWorkeds.Find(id);
			db.HoursWorkeds.Remove(hoursWorked);
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