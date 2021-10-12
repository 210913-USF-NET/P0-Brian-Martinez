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
        
        public ActionResult ViewOrders()
        {
            List<Order> allOrders = _bl.GetCustomerOrder(CustomerController.currentCustomer.Id);
            return View(allOrders);
        }

        public ActionResult SortDate()
        {
            List<Order> allOrders = _bl.GetCustomerOrderNewest(CustomerController.currentCustomer.Id);
            return View(allOrders);
        }

        public ActionResult SortNewDate()
        {
            List<Order> allOrders = _bl.GetCustomerOrderOldest(CustomerController.currentCustomer.Id);
            return View(allOrders);
        }

        public ActionResult Details(int id)
        {
            List<LineItem> orderDetails = _bl.GetOrder(id);
            foreach(LineItem item in orderDetails)
            {
                item.item = _bl.GetProduct(item.ProductId);
            }
            return View(orderDetails);
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
