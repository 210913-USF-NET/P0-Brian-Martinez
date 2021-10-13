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

        public ActionResult Restock()
        {
            List<Inventory> allInventories = _bl.GetInventory();
            return View(allInventories);
        }

        // GET: BrianController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_bl.GetInventoryById(id));
        }

        // POST: BrianController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Inventory invToUpdate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bl.AddInventory(invToUpdate);
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Customers()
        {
            List<Customer> allCustomers = _bl.GetAllCustomers();
            return View(allCustomers);
        }

        public ActionResult Orders(int id)
        {
            List<Order> customerOrders = _bl.GetCustomerOrder(id);
            return View(customerOrders);
        }

        public ActionResult Details(int id)
        {
            List<LineItem> orderDetails = _bl.GetOrder(id);
            foreach (LineItem item in orderDetails)
            {
                item.item = _bl.GetProduct(item.ProductId);
                item.Store = _bl.GetStore((int)item.StoreId);
            }
            return View(orderDetails);
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
    }
}
