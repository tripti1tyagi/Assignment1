using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment1.Models;

namespace Assignment1.Controllers
{
    public class SubcategoriesController : Controller
    {
        private AdbEntities db = new AdbEntities();

        // GET: Subcategories
        public ActionResult Index()
        {
            return View(db.Subcategories.ToList());
        }

        // GET: Subcategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subcategories subcategories = db.Subcategories.Find(id);
            if (subcategories == null)
            {
                return HttpNotFound();
            }
            return View(subcategories);
        }

        // GET: Subcategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Subcategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubcategoryId,SubcategoryName")] Subcategories subcategories)
        {
            if (ModelState.IsValid)
            {
                db.Subcategories.Add(subcategories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subcategories);
        }

        // GET: Subcategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subcategories subcategories = db.Subcategories.Find(id);
            if (subcategories == null)
            {
                return HttpNotFound();
            }
            return View(subcategories);
        }

        // POST: Subcategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubcategoryId,SubcategoryName")] Subcategories subcategories)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subcategories).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subcategories);
        }

        // GET: Subcategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subcategories subcategories = db.Subcategories.Find(id);
            if (subcategories == null)
            {
                return HttpNotFound();
            }
            return View(subcategories);
        }

        // POST: Subcategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subcategories subcategories = db.Subcategories.Find(id);
            db.Subcategories.Remove(subcategories);
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
