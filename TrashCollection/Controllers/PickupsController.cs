using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollection.Models;
using Microsoft.AspNet.Identity;

namespace TrashCollection.Controllers
{
    public class PickupsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        

        // GET: Pickups
        public ActionResult Index()
        {
            CustomerPickupViewModel cpModel = new CustomerPickupViewModel();

            List<Pickup> CustomerPickups = new List<Pickup>();
            var userId = User.Identity.GetUserId();
            CustomerPickups = db.Pickup.Include(x => x.Address.Customer.ApplicationUser).
                Where(g => g.Address.Customer.ApplicationUser.Id == userId).OrderBy(y => y.PickupDate).ToList();

            return View(CustomerPickups.ToList());
        }

        // GET: Pickups/Details/5
        public ActionResult Details()
        {
            //do not erase this, it works//
            Pickup pickup = new Pickup();
            var userId = User.Identity.GetUserId();
            var customerId = db.Customer.First(x => x.UserId == userId).CustomerID;
            pickup.MonthlyPickups = db.Pickup.Include(x => x.Address.Customer).
                Where(g => g.Address.Customer.ApplicationUser.Id == userId).Where(h=> h.Status == true).OrderBy(y => y.PickupDate).ToList();
            //do not erase this, it works//

            DateTime lastDate = DateTime.Now.AddMonths(-1);
            List<Pickup> TruePickups = db.Pickup.Include(x => 
                x.Address.Customer).Where(g => g.Address.Customer.
                ApplicationUser.Id == userId).Where(h => h.Status == true).ToList();
            List<Pickup> anotherList = TruePickups.Where(q => q.PickupDate < DateTime.Today && q.PickupDate.Month > lastDate.Month).ToList();

            int numberOfPickups = anotherList.Count();

            decimal monthlyTotal = 20 * (numberOfPickups);
            pickup.monthlyTotal = monthlyTotal;
            pickup.numberOfPickups = numberOfPickups;

            string todaysDate = Convert.ToString(DateTime.Now.Month) + "/" + Convert.ToString(DateTime.Now.Day) + "/" + Convert.ToString(DateTime.Now.Year);
            pickup.todaysDate = todaysDate;

            return View(pickup);
        }

        // GET: Pickups/Create
        public ActionResult Create()
        {
            var userId = User.Identity.GetUserId();
            var customerId = db.Customer.First(x => x.UserId == userId).CustomerID;
            ViewBag.AddressId = new SelectList(db.Address.Where(g => g.CustomerID == customerId), "AddressID", "Street1");
            return View();
        }

        // POST: Pickups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pickup pickup, bool yearFillConsent)
        {
            if (ModelState.IsValid)
            {
                db.SaveChanges();
                var zipId = db.Address.Where(y => y.AddressID == pickup.AddressID).First().ZipID;
                var empId = db.Employee.Where(y => y.ZipID == zipId).First().EmployeeID;
                pickup.EmployeeID = empId;
                db.Pickup.Add(pickup);
                db.SaveChanges();
                
                if (yearFillConsent == true)
                {

                    List<Pickup> PickupsToDelete = db.Pickup.Where(y => y.PickupDate 
                        > pickup.PickupDate).ToList().Where(z => z.AddressID == 
                        pickup.AddressID).ToList();

                    foreach (Pickup pickupItem in PickupsToDelete)
                    {
                        db.Pickup.Remove(pickupItem);
                        db.SaveChanges();
                    }

                    for (int week = 0; week <52; week++)
                    {
                        Pickup newPickup = new Pickup();
                        newPickup = pickup;
                        DateTime newDate = pickup.PickupDate.AddDays(7);
                        newPickup.PickupDate = newDate;
                        db.Pickup.Add(newPickup);
                        db.SaveChanges();
                    }
                }
                return RedirectToAction("Index");

            }

            ViewBag.AddressID = new SelectList(db.Address, "AddressID", "Street1", pickup.AddressID);
            return View(pickup);
        }

        // GET: Pickups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pickup pickup = db.Pickup.Find(id);
            if (pickup == null)
            {
                return HttpNotFound();
            }
            var userId = User.Identity.GetUserId();
            var customerId = db.Customer.First(x => x.UserId == userId).CustomerID;
            ViewBag.AddressID = new SelectList(db.Address.Where(g => g.CustomerID == customerId), "AddressID", "Street1");

            ViewBag.EmployeeID = new SelectList(db.Employee, "EmployeeID", "FirstName", pickup.EmployeeID);
            return View(pickup);
        }

        // POST: Pickups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PickupID,PickupDate,Status,EmployeeID,AddressID")] Pickup pickup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pickup).State = EntityState.Modified;
                var zipId = db.Address.Where(y => y.AddressID == pickup.AddressID).First().ZipID;
                var empId = db.Employee.Where(y => y.ZipID == zipId).First().EmployeeID;
                pickup.EmployeeID = empId;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AddressID = new SelectList(db.Address, "AddressID", "Street1", pickup.AddressID);
            ViewBag.EmployeeID = new SelectList(db.Employee, "EmployeeID", "FirstName", pickup.EmployeeID);
            return View(pickup);
        }

        // GET: Pickups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pickup pickup = db.Pickup.Find(id);
            if (pickup == null)
            {
                return HttpNotFound();
            }
            return View(pickup);
        }

        // POST: Pickups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pickup pickup = db.Pickup.Find(id);
            db.Pickup.Remove(pickup);
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
