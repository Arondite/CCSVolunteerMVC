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

namespace CCSVolunteerMVC.Controllers
{
    public class CourtOrderedController : Controller
    {
        private CCSContext db = new CCSContext();

        // GET: CourtOrdered
        public ActionResult Index()
        {
            return View(db.CourtOrdereds.ToList());
        }

        // GET: CourtOrdered/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourtOrdered courtOrdered = db.CourtOrdereds.Find(id);
            if (courtOrdered == null)
            {
                return HttpNotFound();
            }
            return View(courtOrdered);
        }

        // GET: CourtOrdered/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourtOrdered/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "courtOrderedID,volunteerID,crtOrderCaseNumber,crtOrderedHoursRequired,crtOrderedStartDate,crtOrderedSexOrViolentCrime,crtOrderedOneMonthLimit")] CourtOrdered courtOrdered)
        {
            if (ModelState.IsValid)
            {
                db.CourtOrdereds.Add(courtOrdered);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courtOrdered);
        }

        // GET: CourtOrdered/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourtOrdered courtOrdered = db.CourtOrdereds.Find(id);
            if (courtOrdered == null)
            {
                return HttpNotFound();
            }
            return View(courtOrdered);
        }

        // POST: CourtOrdered/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "courtOrderedID,volunteerID,crtOrderCaseNumber,crtOrderedHoursRequired,crtOrderedStartDate,crtOrderedSexOrViolentCrime,crtOrderedOneMonthLimit")] CourtOrdered courtOrdered)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courtOrdered).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courtOrdered);
        }

        // GET: CourtOrdered/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourtOrdered courtOrdered = db.CourtOrdereds.Find(id);
            if (courtOrdered == null)
            {
                return HttpNotFound();
            }
            return View(courtOrdered);
        }

        // POST: CourtOrdered/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourtOrdered courtOrdered = db.CourtOrdereds.Find(id);
            db.CourtOrdereds.Remove(courtOrdered);
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
