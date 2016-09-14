using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrashCollection.Controllers
{
    public class CustomerAddressViewModelController : Controller
    {
        // GET: CustomerAddressViewModel
        public ActionResult Index(int id)
        {
            
            return View();
        }

        // GET: CustomerAddressViewModel/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerAddressViewModel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerAddressViewModel/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerAddressViewModel/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerAddressViewModel/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerAddressViewModel/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerAddressViewModel/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
