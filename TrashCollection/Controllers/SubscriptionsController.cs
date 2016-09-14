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
    public class SubscriptionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Subscriptions
        public ActionResult Index()
        {
            var subscription = db.Subscription.Include(s => s.Customer).Include(s => s.Pickup);
            return View(subscription.ToList());
        }

        // GET: Subscriptions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscription subscription = db.Subscription.Find(id);
            if (subscription == null)
            {
                return HttpNotFound();
            }
            return View(subscription);
        }

        // GET: Subscriptions/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customer, "CustomerID", "FirstName");
            ViewBag.PickupID = new SelectList(db.Pickup, "PickupID", "PickupID");
            return View();
        }

        // POST: Subscriptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubscriptionID,PickupID,CustomerID,Fee,AmountPaid,BalanceDue,AutomaticPayments,PaperlessBilling,PaymentMethod")] Subscription subscription)
        {
            if (ModelState.IsValid)
            {
                db.Subscription.Add(subscription);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customer, "CustomerID", "FirstName", subscription.CustomerID);
            ViewBag.PickupID = new SelectList(db.Pickup, "PickupID", "PickupID", subscription.PickupID);
            return View(subscription);
        }

        // GET: Subscriptions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscription subscription = db.Subscription.Find(id);
            if (subscription == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customer, "CustomerID", "FirstName", subscription.CustomerID);
            ViewBag.PickupID = new SelectList(db.Pickup, "PickupID", "PickupID", subscription.PickupID);
            return View(subscription);
        }

        // POST: Subscriptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubscriptionID,PickupID,CustomerID,Fee,AmountPaid,BalanceDue,AutomaticPayments,PaperlessBilling,PaymentMethod")] Subscription subscription)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subscription).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customer, "CustomerID", "FirstName", subscription.CustomerID);
            ViewBag.PickupID = new SelectList(db.Pickup, "PickupID", "PickupID", subscription.PickupID);
            return View(subscription);
        }

        // GET: Subscriptions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscription subscription = db.Subscription.Find(id);
            if (subscription == null)
            {
                return HttpNotFound();
            }
            return View(subscription);
        }

        // POST: Subscriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subscription subscription = db.Subscription.Find(id);
            db.Subscription.Remove(subscription);
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
