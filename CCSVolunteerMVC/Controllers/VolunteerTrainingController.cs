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
    public class VolunteerTrainingController : Controller
    {
        private CCSContext db = new CCSContext();

        // GET: VolunteerTraining
        public ActionResult Index()
        {
            return View(db.VolunteerTrainings.ToList());
        }

        // GET: VolunteerTraining/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VolunteerTraining volunteerTraining = db.VolunteerTrainings.Find(id);
            if (volunteerTraining == null)
            {
                return HttpNotFound();
            }
            return View(volunteerTraining);
        }

        // GET: VolunteerTraining/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VolunteerTraining/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "volunteerTrainingID,volTrnName,volTrnDesc,volTrnCCSRequired,volTrnStateRequired,volTrnMonthsValid,volTrnBackgroundLvl,volTrnMVR")] VolunteerTraining volunteerTraining)
        {
            if (ModelState.IsValid)
            {
                db.VolunteerTrainings.Add(volunteerTraining);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(volunteerTraining);
        }

        // GET: VolunteerTraining/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VolunteerTraining volunteerTraining = db.VolunteerTrainings.Find(id);
            if (volunteerTraining == null)
            {
                return HttpNotFound();
            }
            return View(volunteerTraining);
        }

        // POST: VolunteerTraining/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "volunteerTrainingID,volTrnName,volTrnDesc,volTrnCCSRequired,volTrnStateRequired,volTrnMonthsValid,volTrnBackgroundLvl,volTrnMVR")] VolunteerTraining volunteerTraining)
        {
            if (ModelState.IsValid)
            {
                db.Entry(volunteerTraining).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(volunteerTraining);
        }

        // GET: VolunteerTraining/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VolunteerTraining volunteerTraining = db.VolunteerTrainings.Find(id);
            if (volunteerTraining == null)
            {
                return HttpNotFound();
            }
            return View(volunteerTraining);
        }

        // POST: VolunteerTraining/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VolunteerTraining volunteerTraining = db.VolunteerTrainings.Find(id);
            db.VolunteerTrainings.Remove(volunteerTraining);
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
