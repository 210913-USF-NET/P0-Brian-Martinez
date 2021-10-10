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
    public class ShopController : Controller
    {
        public Customer currentCustomer = CustomerController.currentCustomer;

        private IBL _bl;
        public ShopController(IBL bl)
        {
            _bl = bl;
        }

        public ActionResult Index()
        {
            return View(CustomerController.currentCustomer);
        }

        // GET: ShopController
        public ActionResult PickStore()
        {
            List<StoreFront> allStores = _bl.GetAllStores();
            return View(allStores);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PickStore(int id)
        {
            try
            {
                StoreFront selectedStore = _bl.GetStore(id);
                return RedirectToAction("Shop", "Shop", selectedStore);
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Error in choosing store. Try again.");
                return RedirectToAction("PickStore", "Shop");
            }
        }

        // GET: ShopController/Edit/5
        public ActionResult Shop()
        {
            List<Product> allProducts = _bl.GetProducts();
            return View(allProducts);
        }

        // POST: ShopController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Shop(StoreFront store)
        {
            try
            {
                Order currentOrder = new Order();
                currentOrder = _bl.CreateCart(currentCustomer.Id, store.Id);

                List<LineItem> cartList = new List<LineItem>();
                cartList.Add()
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShopController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShopController/Delete/5
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
