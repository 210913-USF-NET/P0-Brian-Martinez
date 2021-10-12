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
        public Order currentOrder = CustomerController.currentOrder;
        public static StoreFront currentStore;
        public static List<LineItem> cartList = new List<LineItem>();

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
        public ActionResult Order(int id, int item, int quantity)
        {
            StoreFront store = _bl.GetStore(id);
            currentStore = store;
            return RedirectToAction("Checkout", "Order", new { id = currentStore.Id, item = item, quantity = quantity});
        }

        public ActionResult Checkout(int id, int item, int quantity)
        {
/*            Product product = _bl.GetProduct(item);
            ViewBag.Product = product;

            StoreFront store = _bl.GetStore(id);
            ViewBag.StoreFront = store;*/

            LineItem itemToAdd = new LineItem(currentStore.Id, item, quantity, currentOrder.Id);
            /*itemToAdd = _bl.AddLineItem(itemToAdd);*/
            cartList.Add(itemToAdd);
            return View(cartList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Checkout()
        {
            currentOrder.LineItems = cartList;
            Order checkout = _bl.PlaceOrder(currentOrder, currentStore);
            return RedirectToAction("Index", "Shop");
        }

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
