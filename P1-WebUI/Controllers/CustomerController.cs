using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreBL;
using Models;
using P1_WebUI.Models;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace P1_WebUI.Controllers
{
    public class CustomerController : Controller
    {
        public static Customer currentCustomer;
        public static Order currentOrder;

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
                /*currentCustomer = null;*/
                List<Customer> customer = _bl.SearchCustomer(username, password);
                currentCustomer = customer[0];

                if (customer.Count == 0)
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt. Please try again");
                    return View("Login");
                }
                else
                {
/*                    Response.Cookies.Append("CurrentCustomerId", currentCustomer.Id.ToString());
                    Response.Cookies.Append("CurrentCustomerUsername", currentCustomer.Username);*/
                    if (username == "brian" && password == "brian")
                    {
                        Log.Information("Admin logged in");
                        return RedirectToAction("Index", "Brian");
                    }
                    else
                    {
                        Log.Information($"{currentCustomer.Username} logged in");
                        currentOrder = _bl.CreateCart(currentCustomer.Id);
                        return RedirectToAction("Index", "Shop", currentCustomer);
                    }
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
                        if(customer.Age < 21)
                        {
                            ModelState.AddModelError(string.Empty, "Underage people are not allowed. So grow up.");
                            return View("Signup");
                        }
                        else
                        {
                            Log.Information($"{customer.Username} successfully signed up.");
                            _bl.AddCustomer(customer);
                            return View("Login");
                        }
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
