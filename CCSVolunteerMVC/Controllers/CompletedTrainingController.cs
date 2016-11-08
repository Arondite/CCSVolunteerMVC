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
    public class CompletedTrainingController : Controller
    {
        private CCSContext db = new CCSContext();

        // GET: CompletedTraining
        public ActionResult Index()
        {
            return View(db.CompletedTrainings.ToList());
        }

        // GET: CompletedTraining/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompletedTraining completedTraining = db.CompletedTrainings.Find(id);
            if (completedTraining == null)
            {
                return HttpNotFound();
            }
            return View(completedTraining);
        }

        // GET: CompletedTraining/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompletedTraining/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "completedTrainingID,volunteerID,volunteerTrainingID,cmpTrnDate,cmpTrnComments")] CompletedTraining completedTraining)
        {
            if (ModelState.IsValid)
            {
                db.CompletedTrainings.Add(completedTraining);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(completedTraining);
        }

        // GET: CompletedTraining/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompletedTraining completedTraining = db.CompletedTrainings.Find(id);
            if (completedTraining == null)
            {
                return HttpNotFound();
            }
            return View(completedTraining);
        }

        // POST: CompletedTraining/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "completedTrainingID,volunteerID,volunteerTrainingID,cmpTrnDate,cmpTrnComments")] CompletedTraining completedTraining)
        {
            if (ModelState.IsValid)
            {
                db.Entry(completedTraining).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(completedTraining);
        }

        // GET: CompletedTraining/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompletedTraining completedTraining = db.CompletedTrainings.Find(id);
            if (completedTraining == null)
            {
                return HttpNotFound();
            }
            return View(completedTraining);
        }

        // POST: CompletedTraining/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompletedTraining completedTraining = db.CompletedTrainings.Find(id);
            db.CompletedTrainings.Remove(completedTraining);
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
