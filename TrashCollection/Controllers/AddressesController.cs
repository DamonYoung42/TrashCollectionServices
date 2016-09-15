using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TrashCollection.Models;

namespace TrashCollection.Controllers
{
    public class AddressesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Addresses
        public ActionResult Index()
        {
            //var userId = User.Identity.GetUserId();
            //var t = db.Customer.Include(y => y.ApplicationUser).Include(y => y.Address);
            //var m = db.Customer.Include(x => x.ApplicationUser).Include(x => x.Address).Where(x => x.ApplicationUser.Id == userId);
            //var model = db.Customer.Include(x => x.ApplicationUser).Include(x => x.Address).Where(x => x.ApplicationUser.Id == userId).Select(x => x.Address).ToList();
            //var address = db.Address.Include(a => a.City).Include(a => a.Zipcode);
            //return View(model);
            return View();
        }

        // GET: Addresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Address.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // GET: Addresses/Create
        public ActionResult Create()
        {
            ViewBag.CityID = new SelectList(db.City, "CityID", "CityName");
            ViewBag.ZipID = new SelectList(db.Zipcode, "ZipID", "ZipcodeName");
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AddressID,Street1,Street2,CityID,ZipID")] Address address)
        {
            if (ModelState.IsValid)
            {
                db.Address.Add(address);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityID = new SelectList(db.City, "CityID", "CityName", address.CityID);
            ViewBag.ZipID = new SelectList(db.Zipcode, "ZipID", "ZipcodeName", address.ZipID);
            return View(address);
        }

        // GET: Addresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Address.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityID = new SelectList(db.City, "CityID", "CityName", address.CityID);
            ViewBag.ZipID = new SelectList(db.Zipcode, "ZipID", "ZipcodeName", address.ZipID);
            return View(address);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AddressID,Street1,Street2,CityID,ZipID")] Address address)
        {
            if (ModelState.IsValid)
            {
                db.Entry(address).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityID = new SelectList(db.City, "CityID", "CityName", address.CityID);
            ViewBag.ZipID = new SelectList(db.Zipcode, "ZipID", "ZipcodeName", address.ZipID);
            return View(address);
        }

        // GET: Addresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Address.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Address address = db.Address.Find(id);
            db.Address.Remove(address);
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
