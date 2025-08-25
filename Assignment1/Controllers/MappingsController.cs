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
    public class MappingsController : Controller
    {
        private AdbEntities db = new AdbEntities();

        // GET: Mappings
        public ActionResult Index()
        {
            var categorySubcategoryMappings = db.CategorySubcategoryMappings.Include(c => c.Categories).Include(c => c.Subcategories);
            return View(categorySubcategoryMappings.ToList());
        }

        // GET: Mappings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategorySubcategoryMappings categorySubcategoryMappings = db.CategorySubcategoryMappings.Find(id);
            if (categorySubcategoryMappings == null)
            {
                return HttpNotFound();
            }
            return View(categorySubcategoryMappings);
        }

        // GET: Mappings/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            ViewBag.SubcategoryId = new SelectList(db.Subcategories, "SubcategoryId", "SubcategoryName");
            return View();
        }

        // POST: Mappings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CategoryId,SubcategoryId")] CategorySubcategoryMappings categorySubcategoryMappings)
        {
            if (ModelState.IsValid)
            {
                db.CategorySubcategoryMappings.Add(categorySubcategoryMappings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", categorySubcategoryMappings.CategoryId);
            ViewBag.SubcategoryId = new SelectList(db.Subcategories, "SubcategoryId", "SubcategoryName", categorySubcategoryMappings.SubcategoryId);
            return View(categorySubcategoryMappings);
        }

        // GET: Mappings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategorySubcategoryMappings categorySubcategoryMappings = db.CategorySubcategoryMappings.Find(id);
            if (categorySubcategoryMappings == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", categorySubcategoryMappings.CategoryId);
            ViewBag.SubcategoryId = new SelectList(db.Subcategories, "SubcategoryId", "SubcategoryName", categorySubcategoryMappings.SubcategoryId);
            return View(categorySubcategoryMappings);
        }

        // POST: Mappings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CategoryId,SubcategoryId")] CategorySubcategoryMappings categorySubcategoryMappings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categorySubcategoryMappings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", categorySubcategoryMappings.CategoryId);
            ViewBag.SubcategoryId = new SelectList(db.Subcategories, "SubcategoryId", "SubcategoryName", categorySubcategoryMappings.SubcategoryId);
            return View(categorySubcategoryMappings);
        }

        // GET: Mappings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategorySubcategoryMappings categorySubcategoryMappings = db.CategorySubcategoryMappings.Find(id);
            if (categorySubcategoryMappings == null)
            {
                return HttpNotFound();
            }
            return View(categorySubcategoryMappings);
        }

        // POST: Mappings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategorySubcategoryMappings categorySubcategoryMappings = db.CategorySubcategoryMappings.Find(id);
            db.CategorySubcategoryMappings.Remove(categorySubcategoryMappings);
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
