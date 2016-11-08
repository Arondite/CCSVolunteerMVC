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
    public class PositionLocationController : Controller
    {
        private CCSContext db = new CCSContext();

        // GET: PositionLocation
        public ActionResult Index()
        {
            return View(db.PositionLocations.ToList());
        }

        // GET: PositionLocation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PositionLocation positionLocation = db.PositionLocations.Find(id);
            if (positionLocation == null)
            {
                return HttpNotFound();
            }
            return View(positionLocation);
        }

        // GET: PositionLocation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PositionLocation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "positionLocationID,posLocationName,posLocationStreet1,posLocationStreet2,posLocationCity,posLocationState,posLocationZip,posLocationNotes")] PositionLocation positionLocation)
        {
            if (ModelState.IsValid)
            {
                db.PositionLocations.Add(positionLocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(positionLocation);
        }

        // GET: PositionLocation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PositionLocation positionLocation = db.PositionLocations.Find(id);
            if (positionLocation == null)
            {
                return HttpNotFound();
            }
            return View(positionLocation);
        }

        // POST: PositionLocation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "positionLocationID,posLocationName,posLocationStreet1,posLocationStreet2,posLocationCity,posLocationState,posLocationZip,posLocationNotes")] PositionLocation positionLocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(positionLocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(positionLocation);
        }

        // GET: PositionLocation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PositionLocation positionLocation = db.PositionLocations.Find(id);
            if (positionLocation == null)
            {
                return HttpNotFound();
            }
            return View(positionLocation);
        }

        // POST: PositionLocation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PositionLocation positionLocation = db.PositionLocations.Find(id);
            db.PositionLocations.Remove(positionLocation);
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
