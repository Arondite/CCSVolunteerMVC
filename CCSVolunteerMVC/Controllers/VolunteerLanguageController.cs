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
    public class VolunteerLanguageController : Controller
    {
        private CCSContext db = new CCSContext();

        // GET: VolunteerLanguage
        public ActionResult Index()
        {
            var volunteerLanguages = db.VolunteerLanguages.Include(v => v.foreignLanguage).Include(v => v.volunteer);
            return View(volunteerLanguages.ToList());
        }

        // GET: VolunteerLanguage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VolunteerLanguage volunteerLanguage = db.VolunteerLanguages.Find(id);
            if (volunteerLanguage == null)
            {
                return HttpNotFound();
            }
            return View(volunteerLanguage);
        }

        // GET: VolunteerLanguage/Create
        public ActionResult Create()
        {
            ViewBag.foreignLanguageID = new SelectList(db.ForeignLanguages, "foreignLanguageID", "foreignLangName");
            ViewBag.volunteerID = new SelectList(db.Volunteers, "volunteerID", "volFirstName");
            return View();
        }

        // POST: VolunteerLanguage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "volunteerLanguageID,volunteerID,foreignLanguageID,volLangFluencyLvl,volLangLiteracyLvl")] VolunteerLanguage volunteerLanguage)
        {
            if (ModelState.IsValid)
            {
                db.VolunteerLanguages.Add(volunteerLanguage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.foreignLanguageID = new SelectList(db.ForeignLanguages, "foreignLanguageID", "foreignLangName", volunteerLanguage.foreignLanguageID);
            ViewBag.volunteerID = new SelectList(db.Volunteers, "volunteerID", "volFirstName", volunteerLanguage.volunteerID);
            return View(volunteerLanguage);
        }

        // GET: VolunteerLanguage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VolunteerLanguage volunteerLanguage = db.VolunteerLanguages.Find(id);
            if (volunteerLanguage == null)
            {
                return HttpNotFound();
            }
            ViewBag.foreignLanguageID = new SelectList(db.ForeignLanguages, "foreignLanguageID", "foreignLangName", volunteerLanguage.foreignLanguageID);
            ViewBag.volunteerID = new SelectList(db.Volunteers, "volunteerID", "volFirstName", volunteerLanguage.volunteerID);
            return View(volunteerLanguage);
        }

        // POST: VolunteerLanguage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "volunteerLanguageID,volunteerID,foreignLanguageID,volLangFluencyLvl,volLangLiteracyLvl")] VolunteerLanguage volunteerLanguage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(volunteerLanguage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.foreignLanguageID = new SelectList(db.ForeignLanguages, "foreignLanguageID", "foreignLangName", volunteerLanguage.foreignLanguageID);
            ViewBag.volunteerID = new SelectList(db.Volunteers, "volunteerID", "volFirstName", volunteerLanguage.volunteerID);
            return View(volunteerLanguage);
        }

        // GET: VolunteerLanguage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VolunteerLanguage volunteerLanguage = db.VolunteerLanguages.Find(id);
            if (volunteerLanguage == null)
            {
                return HttpNotFound();
            }
            return View(volunteerLanguage);
        }

        // POST: VolunteerLanguage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VolunteerLanguage volunteerLanguage = db.VolunteerLanguages.Find(id);
            db.VolunteerLanguages.Remove(volunteerLanguage);
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
