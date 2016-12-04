﻿using System;
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


			var totalHoursWorked = new TotalHoursWorkedViewModel();
			var listOfWorkDates = new List<WorkDate>();


			var dayQuerySingle = db.HoursWorkeds.Where(r => r.hrsWrkedSchedDate.Date >= startDate && r.hrsWrkedSchedDate.Date <= endDate)
			.Select(r => r);



			foreach (var day in db.HoursWorkeds
				.Where(r => r.hrsWrkedSchedDate.Date >= startDate && r.hrsWrkedSchedDate.Date <= endDate).
				Select(p => p.hrsWrkedSchedDate).Distinct())
			{
				WorkDate temp = new WorkDate();
				temp.day = day; // temp workdate to add to list through iterations
				temp.individualHours = 0;
				temp.groupHours = 0;
				listOfWorkDates.Add(temp);
			}

			foreach (var record in dayQuerySingle)
			{
				foreach (WorkDate workDay in listOfWorkDates)
				{
					if (workDay.day.Date == record.hrsWrkedSchedDate.Date)
					{
						if (record.volunteerID != null) // if individual volunteer
						{
							workDay.individualHours += record.hrsWrkdQty;
						}
						else if (record.volunteerID == null) // if group volunteer
						{
							workDay.groupHours += record.hrsWrkdQty;
						}
					}
				}
			}

			foreach (WorkDate workDay in listOfWorkDates)
			{
				totalHoursWorked.individualTotal += workDay.individualHours;
				totalHoursWorked.groupTotal += workDay.groupHours;
			}

			totalHoursWorked.workDates = listOfWorkDates;
			totalHoursWorked.startingDay = (DateTime)(startDate);
			totalHoursWorked.endingDay = (DateTime)endDate;


			return View(totalHoursWorked);
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
