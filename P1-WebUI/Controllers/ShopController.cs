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
/*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PickStore(int id)
        {
            try
            {
                StoreFront store = _bl.GetStore(id);
                currentStore = store;
                return RedirectToAction("Order", "Order", currentStore);
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Error in choosing store. Try again.");
                return RedirectToAction("PickStore", "Shop");
            }
        }*/

/*        // GET: ShopController/Edit/5
        public ActionResult Order(StoreFront store)
        {
            Order currentOrder = new Order();
            currentOrder = _bl.CreateCart(currentCustomer.Id, store.Id);
            List<Product> allProducts = _bl.GetProducts();
            return View(allProducts);
        }

        // POST: ShopController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Order(Order order, Product product, int quantity)
        {
            try
            {
                Inventory storeInv = _bl.GetInventoryById(order.StoreId, product.Id);
                List<LineItem> cartList = new List<LineItem>();
                if (quantity > storeInv.Quantity)
                {
                    ModelState.AddModelError(string.Empty, "Cannot select more than we have in stock. Try again.");
                    return RedirectToAction("Shop", "Shop");
                }
                else
                {
                    LineItem itemToAdd = new LineItem(order.StoreId, product.Id, quantity, order.Id);
                    cartList.Add(itemToAdd);
                    return View("MoreShop");
                }
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Shopping error. Try again.");
                return RedirectToAction("Index", "Home");
            }
        }*/

        // GET: ShopController/Delete/5
        public ActionResult MoreShop(List<LineItem> cart)
        {
            return View(cart);
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
