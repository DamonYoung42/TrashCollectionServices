using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollection.Models;

namespace TrashCollection.Controllers
{
    public class CustomerPickupJuncturesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CustomerPickupJunctures
        public ActionResult Index()
        {
            var customerPickupJuncture = db.CustomerPickupJuncture.Include(c => c.Customer).Include(c => c.Pickup);
            return View(customerPickupJuncture.ToList());
        }

        // GET: CustomerPickupJunctures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerPickupJuncture customerPickupJuncture = db.CustomerPickupJuncture.Find(id);
            if (customerPickupJuncture == null)
            {
                return HttpNotFound();
            }
            return View(customerPickupJuncture);
        }

        // GET: CustomerPickupJunctures/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customer, "CustomerID", "FirstName");
            ViewBag.PickupID = new SelectList(db.Pickup, "PickupID", "PickupID");
            return View();
        }

        // POST: CustomerPickupJunctures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerPickupJunctureID,CustomerID,PickupID")] CustomerPickupJuncture customerPickupJuncture)
        {
            if (ModelState.IsValid)
            {
                db.CustomerPickupJuncture.Add(customerPickupJuncture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customer, "CustomerID", "FirstName", customerPickupJuncture.CustomerID);
            ViewBag.PickupID = new SelectList(db.Pickup, "PickupID", "PickupID", customerPickupJuncture.PickupID);
            return View(customerPickupJuncture);
        }

        // GET: CustomerPickupJunctures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerPickupJuncture customerPickupJuncture = db.CustomerPickupJuncture.Find(id);
            if (customerPickupJuncture == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customer, "CustomerID", "FirstName", customerPickupJuncture.CustomerID);
            ViewBag.PickupID = new SelectList(db.Pickup, "PickupID", "PickupID", customerPickupJuncture.PickupID);
            return View(customerPickupJuncture);
        }

        // POST: CustomerPickupJunctures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerPickupJunctureID,CustomerID,PickupID")] CustomerPickupJuncture customerPickupJuncture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerPickupJuncture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customer, "CustomerID", "FirstName", customerPickupJuncture.CustomerID);
            ViewBag.PickupID = new SelectList(db.Pickup, "PickupID", "PickupID", customerPickupJuncture.PickupID);
            return View(customerPickupJuncture);
        }

        // GET: CustomerPickupJunctures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerPickupJuncture customerPickupJuncture = db.CustomerPickupJuncture.Find(id);
            if (customerPickupJuncture == null)
            {
                return HttpNotFound();
            }
            return View(customerPickupJuncture);
        }

        // POST: CustomerPickupJunctures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerPickupJuncture customerPickupJuncture = db.CustomerPickupJuncture.Find(id);
            db.CustomerPickupJuncture.Remove(customerPickupJuncture);
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
