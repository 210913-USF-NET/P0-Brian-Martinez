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
    public class OrderController : Controller
    {
        public Customer currentCustomer = CustomerController.currentCustomer;
        public StoreFront selectedStore = ShopController.selectedStore;

        private IBL _bl;
        public OrderController(IBL bl)
        {
            _bl = bl;
        }

        // GET: ShopController/Edit/5
        public ActionResult Order()
        {
            List<Product> allProducts = _bl.GetProducts();
            return View(allProducts);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Order(int id)
        {
            StoreFront store = _bl.GetStore(id);
            Order currentOrder = new Order();
            currentOrder = _bl.CreateCart(currentCustomer.Id, store.Id);
            return View();
        }

/*        // POST: ShopController/Edit/5
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




        // GET: OrderController
        public ActionResult Index()
        {
            return View();
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
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

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
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
