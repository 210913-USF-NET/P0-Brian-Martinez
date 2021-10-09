using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using StoreBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P1_WebUI.Controllers
{
    public class BrianController : Controller
    {
        private IBL _bl;

        public BrianController(IBL bl)
        {
            _bl = bl;
        }

        // GET: BrianController
        public ActionResult Index()
        {
            return View();
        }

        // GET: BrianController/Create
        public ActionResult CreateStore()
        {
            return View();
        }

        // POST: BrianController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateStore(StoreFront store)
        {
            try
            {
                //if the data in my form is valid
                if (ModelState.IsValid)
                {
                    _bl.AddStore(store);
                    return View("Index");
                }
                return View("Index");
            }
            catch
            {
                return View("Index");
            }
        }

        // GET: BrianController/Create
        public ActionResult CreateProduct()
        {
            return View();
        }

        // POST: BrianController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProduct(Product product)
        {
            try
            {
                //if the data in my form is valid
                if (ModelState.IsValid)
                {
                    _bl.AddProduct(product);
                    return View("Index");
                }
                return View("Index");
            }
            catch
            {
                return View("Index");
            }
        }

        // GET: BrianController/Create
        public ActionResult CreateInventory()
        {
            return View();
        }

        // POST: BrianController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateInventory(Inventory inventory)
        {
            try
            {
                //if the data in my form is valid
                if (ModelState.IsValid)
                {
                    _bl.CreateInventory(inventory);
                    return View("Index");
                }
                return View("Index");
            }
            catch
            {
                return View("Index");
            }
        }

        // GET: BrianController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BrianController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BrianController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BrianController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
