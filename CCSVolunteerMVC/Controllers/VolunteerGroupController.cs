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
    public class VolunteerGroupController : Controller
    {
        private CCSContext db = new CCSContext();

        // GET: VolunteerGroup
        public ActionResult Index()
        {
            return View(db.VolunteerGroups.ToList());
        }

        // GET: VolunteerGroup/Details/5
        public ActionResult Details(int? id)
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

        // GET: VolunteerGroup/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VolunteerGroup/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "volunteerGroupID,volGrpName,volGrpUserName,volGrpPasswordHash,volGrpAddress1,volGrpAddress2,volGrpState,volGrpZip,volGrpIsActive")] VolunteerGroup volunteerGroup)
        {
            if (ModelState.IsValid)
            {
                db.VolunteerGroups.Add(volunteerGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(volunteerGroup);
        }

        // GET: VolunteerGroup/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: VolunteerGroup/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "volunteerGroupID,volGrpName,volGrpUserName,volGrpPasswordHash,volGrpAddress1,volGrpAddress2,volGrpState,volGrpZip,volGrpIsActive")] VolunteerGroup volunteerGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(volunteerGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(volunteerGroup);
        }

        // GET: VolunteerGroup/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: VolunteerGroup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VolunteerGroup volunteerGroup = db.VolunteerGroups.Find(id);
            db.VolunteerGroups.Remove(volunteerGroup);
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
