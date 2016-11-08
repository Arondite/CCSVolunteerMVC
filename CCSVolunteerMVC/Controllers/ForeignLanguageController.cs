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
    public class ForeignLanguageController : Controller
    {
        private CCSContext db = new CCSContext();

        // GET: ForeignLanguage
        public ActionResult Index()
        {
            return View(db.ForeignLanguages.ToList());
        }

        // GET: ForeignLanguage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForeignLanguage foreignLanguage = db.ForeignLanguages.Find(id);
            if (foreignLanguage == null)
            {
                return HttpNotFound();
            }
            return View(foreignLanguage);
        }

        // GET: ForeignLanguage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ForeignLanguage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "foreignLanguageID,foreignLangName")] ForeignLanguage foreignLanguage)
        {
            if (ModelState.IsValid)
            {
                db.ForeignLanguages.Add(foreignLanguage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(foreignLanguage);
        }

        // GET: ForeignLanguage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForeignLanguage foreignLanguage = db.ForeignLanguages.Find(id);
            if (foreignLanguage == null)
            {
                return HttpNotFound();
            }
            return View(foreignLanguage);
        }

        // POST: ForeignLanguage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "foreignLanguageID,foreignLangName")] ForeignLanguage foreignLanguage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foreignLanguage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(foreignLanguage);
        }

        // GET: ForeignLanguage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForeignLanguage foreignLanguage = db.ForeignLanguages.Find(id);
            if (foreignLanguage == null)
            {
                return HttpNotFound();
            }
            return View(foreignLanguage);
        }

        // POST: ForeignLanguage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ForeignLanguage foreignLanguage = db.ForeignLanguages.Find(id);
            db.ForeignLanguages.Remove(foreignLanguage);
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
