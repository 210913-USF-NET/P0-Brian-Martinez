using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreBL;
using Models;
using P1_WebUI.Models;

namespace P1_WebUI.Controllers
{
    public class CustomerController : Controller
    {
        public static Customer currentCustomer;

        private IBL _bl;

        public CustomerController(IBL bl)
        {
            _bl = bl;
        }

        public ActionResult Login()
        {
            return View();
        }

        // GET: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            try
            {
                var customer = _bl.SearchCustomer(username, password);
                currentCustomer = customer[0];
                if (customer.Count == 0)
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt. Please try again");
                    return View("Login");
                }
                else
                {
                    if (username == "brian" && password == "brian")
                    {
                        return RedirectToAction("Index", "Brian");
                    }
                    return RedirectToAction("Index", "Shop", currentCustomer);
                }
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt. Please try again");
                return View("Login");
            }
        }

        public ActionResult Signup()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signup(Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var check = _bl.Search(customer.Username);
                    if (check.Count == 0)
                    {
                        _bl.AddCustomer(customer);
                        currentCustomer = customer;
                        return RedirectToAction("Index", "Shop", currentCustomer);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Username already exists. Please try again");
                        return View("Signup");
                    }
                }
                return View("Signup");
            }
            catch
            {
                return View();
            }
        }
    }
}
