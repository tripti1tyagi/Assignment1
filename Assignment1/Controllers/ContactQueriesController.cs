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
    [Authorize]
    public class ContactQueriesController : Controller
    {
        private AdbEntities db = new AdbEntities();

       //  GET: ContactQueries
       /* public ActionResult Index()
        {
            return View(db.ContactQueries.ToList());
        }*/

        [Authorize] // Ensures the user is logged in
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return new HttpUnauthorizedResult("You must be logged in.");
            }

            var allowedUsers = new[] { "admin", "tessa" };

            // Compare ignoring case
            string currentUser = User.Identity.Name?.ToLower();

            if (!allowedUsers.Contains(currentUser))
            {
                return new HttpUnauthorizedResult("Access Denied");
            }

            return View(db.ContactQueries.ToList());
        }


        /*  [Authorize]
  public ActionResult Index()
  {
      var allowedUsers = new[] { "admin", "tessa" };
      if (!allowedUsers.Contains(User.Identity.Name.ToLower()))
      {
          return new HttpUnauthorizedResult("Access Denied");
      }

      return View(db.ContactQueries.ToList());
  }
  */

        // GET: ContactQueries/Details/5

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactQuery contactQuery = db.ContactQueries.Find(id);
            if (contactQuery == null)
            {
                return HttpNotFound();
            }
            return View(contactQuery);
        }
        // GET: ContactQueries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactQueries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,ContactNo,EmailId,QueryText,SubmitDate")] ContactQuery contactQuery)
        {
            if (ModelState.IsValid)
            {
                db.ContactQueries.Add(contactQuery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactQuery);
        }

        // GET: ContactQueries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactQuery contactQuery = db.ContactQueries.Find(id);
            if (contactQuery == null)
            {
                return HttpNotFound();
            }
            return View(contactQuery);
        }

        // POST: ContactQueries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,ContactNo,EmailId,QueryText,SubmitDate")] ContactQuery contactQuery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactQuery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactQuery);
        }

        // GET: ContactQueries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactQuery contactQuery = db.ContactQueries.Find(id);
            if (contactQuery == null)
            {
                return HttpNotFound();
            }
            return View(contactQuery);
        }

        // POST: ContactQueries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactQuery contactQuery = db.ContactQueries.Find(id);
            db.ContactQueries.Remove(contactQuery);
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