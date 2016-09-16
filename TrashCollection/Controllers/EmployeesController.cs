using Microsoft.AspNet.Identity;
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
            employeePickups = db.Pickup.ToList().Where(g=> g.EmployeeID == epModel.employee.EmployeeID).ToList();
            epModel.employeePickups = employeePickups;

            //PickupAddressJunc pAJ = db.PickupAddressJunc.Where(x => x.PickupID == epModel.pickup.PickupID).First();
            //var address = db.Address.Where(y => y.AddressID == pAJ.AddressID);

            
           

            //foreach (Pickup pickupItem in employeePickups)
            //{
            //    epModel.pAJ = db.PickupAddressJunc.Where(x => x.PickupID == pickupItem.PickupID).First();
            //    var address = db.Address.Where(y=>y.AddressID == epModel.pAJ.AddressID);
            //}
            //int addressForPickupID = epModel.address.AddressID;

            //var address = db.Address.Where(g => g.AddressID == epModel.pAJ.AddressID)/*.Select(n => n.AddressID).First()*/;

            //epModel.address.AddressID = epModel.GetAddressIDForPickup(epModel.pickup.PickupID);
            //var employee = context.Employee.Where(y => y.UserId == userId).Select(m => m.EmployeeID);
            //pAJ.AddressID = db.PickupAddressJunc.Where(pAJ.PickupID == epModel.pickup.PickupID);
            //address.AddressID = db.PickupAddressJunc.Find(epModel.pickup.PickupID);
            //int AddressID = epModel.pickupAddressJunc.AddressID.Where(g => g.PickupID == epModel.pickup.PickupID);

            return View(epModel);

        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,FirstName,LastName,EmailAddress")] Employee employee)
        {
            if (ModelState.IsValid)
            {
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
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,FirstName,LastName,UserId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Details/" + employee.EmployeeID, "Employees");
            }
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



