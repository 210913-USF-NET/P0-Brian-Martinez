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
                if (customer.Count == 0)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt. Please try again");
                    return View("Login");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch
            {
                return RedirectToAction("Index", "Home");
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
/*            try
            {
                if (ModelState.IsValid)
                {
                    bool check = _bl.Search(customer.Username);
                    if (check == false)
                    {
                        _bl.AddCustomer(customer);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }*/

            try
            {
                if (ModelState.IsValid)
                {
                    _bl.AddCustomer(customer);
                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }
    }
}
