using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using TrashCollection.Models;

namespace TrashCollection.Controllers
{
    //[Authorize(Roles = "Employee")]
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employees
        public ActionResult Index()
        {
            return View(db.Employee.ToList());
        }

        // GET: Employees/Details
        public ActionResult Details(int? id)
        {
            EmployeePickupViewModel epModel = new EmployeePickupViewModel();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            epModel.employee = db.Employee.Find(id);
            if (epModel.employee == null)
            {
                return HttpNotFound();
            }
            List<Pickup> employeePickups = new List<Pickup>();
            //do not erase this, it works
            employeePickups = db.Pickup.Where(x => x.PickupDate.Month.Equals(DateTime.Now.Month)&& x.PickupDate.Day.Equals(DateTime.Now.Day)).Include(X => X.Address).Include(p => p.Address.City.State).Include(q => q.Address.Zipcode).ToList().Where(g => g.EmployeeID == epModel.employee.EmployeeID).ToList();
            //do not erase this, it works

            epModel.employeePickups = employeePickups;
            List<string> employeePickupAddresses = new List<string>();

            foreach (Pickup pickupItem in employeePickups)
            {
                employeePickupAddresses.Add(pickupItem.Address.Street1+","+ pickupItem.Address.Street2+","+ pickupItem.Address.City.CityName + "," + pickupItem.Address.City.State.StateName);

            }
            epModel.employeePickupAddresses = employeePickupAddresses;

            return View(epModel);

        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.UserId = User.Identity.GetUserId();
            ViewBag.ZipID = new SelectList(db.Zipcode, "ZipID", "ZipcodeName");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,FirstName,LastName,EmailAddress,ZipID")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                //employee.UserId = employee.ApplicationUser.Id;
                var userId = User.Identity.GetUserId();
                employee.UserId = userId;
                db.Employee.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Details/"+employee.EmployeeID);
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.ZipID = new SelectList(db.Zipcode, "ZipID", "ZipcodeName", employee.ZipID);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,FirstName,LastName,UserId,ZipID")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Details/" + employee.EmployeeID, "Employees");
            }
            ViewBag.ZipID = new SelectList(db.Zipcode, "ZipID", "ZipcodeName", employee.ZipID);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.ZipID = new SelectList(db.Zipcode, "ZipID", "ZipcodeName", employee.ZipID);
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employee.Find(id);
            db.Employee.Remove(employee);
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



