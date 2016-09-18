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

            List<Pickup> customerPickups = new List<Pickup>();
            //SELECT column_name, aggregate_function(column_name)
            //FROM table_name
            //WHERE column_name operator value
            //GROUP BY column_name;
            var userId = User.Identity.GetUserId();
            customerPickups = db.Pickup.Include(x => x.Address.Customer.ApplicationUser).
                Where(g => g.Address.Customer.ApplicationUser.Id == userId).OrderBy(y=>y.PickupDate).ToList();
            //List<Pickup> monthlyPickups = new List<Pickup>();
            //monthlyPickups = db.Pickup.Where(x => x.PickupDate > DateTime.Now.AddMonths(-1)).
            //    Where(y => y.Status == true).Where(g => g.Address.Customer.ApplicationUser.Id
            //      == userId).ToList();
            //cpModel.monthlyTotal = 20 * (monthlyPickups.Count());



            return View(customerPickups.ToList());
        }

        // GET: Pickups/Details/5
        public ActionResult Details(int? id)
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

        // GET: Pickups/Create
        public ActionResult Create()
        {
            var userId = User.Identity.GetUserId();
            var customerId = db.Customer.First(x => x.UserId == userId).CustomerID;
            ViewBag.AddressId = new SelectList(db.Address.Where(g => g.CustomerID == customerId), "AddressID", "Street1");
            EmployeePickupViewModel epModel = new EmployeePickupViewModel();
            //ViewBag.AddressID = new SelectList(db.Address, "AddressID", "Street1");
            //ViewBag.EmployeeID = new SelectList(db.Employee, "EmployeeID", "FirstName");
            return View();
        }

        // POST: Pickups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PickupID,PickupDate,Status,EmployeeID,AddressID, Address, Employee")] Pickup pickup)
        {
            if (ModelState.IsValid)
            {
                var zipId = db.Address.Where(y => y.AddressID == pickup.AddressID).First().ZipID;
                var empId = db.Employee.Where(y => y.ZipID == zipId).First().EmployeeID;
                pickup.EmployeeID = empId;
                db.Pickup.Add(pickup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AddressID = new SelectList(db.Address, "AddressID", "Street1", pickup.AddressID);
            //ViewBag.EmployeeID = new SelectList(db.Employee, "EmployeeID", "FirstName", pickup.EmployeeID);
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
            //ViewBag.AddressID = new SelectList(db.Address, "AddressID", "Street1", pickup.AddressID);
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
