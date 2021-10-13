using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using StoreBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;

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
            LineItem itemToAdd = new LineItem(currentStore.Id, item, quantity, currentOrder.Id);
            itemToAdd.item = _bl.GetProduct(itemToAdd.ProductId);
            /*itemToAdd = _bl.AddLineItem(itemToAdd);*/
            cartList.Add(itemToAdd);
            Log.Information($"LineItem added to cart");
            return View(cartList);
        }

        // GET: OrderController
        public ActionResult PlaceOrder()
        {
            currentOrder.LineItems = cartList;
            _bl.PlaceOrder(currentOrder, currentStore);
            foreach (LineItem item in currentOrder.LineItems)
            {
                _bl.UpdateInventory(currentStore, item);
            }
            cartList.Clear();
            Log.Information($"Order successfully placed");
            return RedirectToAction("Index", "Shop");
        }

        public ActionResult ClearCart()
        {
            currentOrder.LineItems = cartList;
            cartList.Clear();
            return RedirectToAction("Index", "Shop");
        }
    }
}
