using System;
using Models;
using StoreBL;
using DL;
using System.Collections.Generic;

namespace UI
{
    public class CustomerMenu :IMenu
    {
        private IBL _bl;

        public CustomerMenu(IBL bl)
        {
            _bl = bl;
        }

        public void Start()
        {
            bool exit = false;
            do
            {
                Console.WriteLine("[1] Shop");
                Console.WriteLine("[2] View Order(s)");
                Console.WriteLine("[3] View Locations");
                Console.WriteLine("[x] Back to Main Menu");

                switch (Console.ReadLine())
                {
                    case "1":
                        new ShopChooseLocationMenu(new BL(new FileRepo())).Start();
                        break;
                    case "2":
                        Console.WriteLine("View order");
                        break;
                    case "3":
                        new ChooseLocationMenu().Start();
                        break;
                    case "x":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            } while (!exit);
        }

        public void ViewOrders()
        {
            List<Order> allOrders = _bl.GetAllOrders();
            if (allOrders == null || allOrders.Count == 0)
            {
                Console.WriteLine("No Orders");
                return;
            }
            for (int i = 0; i < allOrders.Count; i++)
            {
                Console.WriteLine($"[{i}] {allOrders[i]}");
            }
        }
    }
}