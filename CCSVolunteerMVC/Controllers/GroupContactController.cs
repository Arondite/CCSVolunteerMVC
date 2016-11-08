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
    public class GroupContactController : Controller
    {
        private CCSContext db = new CCSContext();

        // GET: GroupContact
        public ActionResult Index()
        {
            return View(db.GroupContacts.ToList());
        }

        // GET: GroupContact/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupContact groupContact = db.GroupContacts.Find(id);
            if (groupContact == null)
            {
                return HttpNotFound();
            }
            return View(groupContact);
        }

        // GET: GroupContact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GroupContact/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "groupContactID,grpContName,contactTypeID,volunteerGroupID,grpContInfo")] GroupContact groupContact)
        {
            if (ModelState.IsValid)
            {
                db.GroupContacts.Add(groupContact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(groupContact);
        }

        // GET: GroupContact/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupContact groupContact = db.GroupContacts.Find(id);
            if (groupContact == null)
            {
                return HttpNotFound();
            }
            return View(groupContact);
        }

        // POST: GroupContact/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "groupContactID,grpContName,contactTypeID,volunteerGroupID,grpContInfo")] GroupContact groupContact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(groupContact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(groupContact);
        }

        // GET: GroupContact/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupContact groupContact = db.GroupContacts.Find(id);
            if (groupContact == null)
            {
                return HttpNotFound();
            }
            return View(groupContact);
        }

        // POST: GroupContact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GroupContact groupContact = db.GroupContacts.Find(id);
            db.GroupContacts.Remove(groupContact);
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
