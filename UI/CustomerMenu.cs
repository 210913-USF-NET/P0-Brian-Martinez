using System;
using Models;
using StoreBL;
using DL;
using System.Collections.Generic;

namespace UI
{
    public class CustomerMenu : IMenu
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
                Console.WriteLine("[3] View Products");
                Console.WriteLine("[x] Back to Main Menu");

                switch (Console.ReadLine())
                {
                    case "1":
                        MenuFactory.GetMenu("shop").Start();
                        break;
                    case "2":
                        Console.WriteLine("View order");
                        break;
                    case "3":
                        ViewProducts();
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

        public void ViewProducts()
        {
            List<Product> allProducts = _bl.GetProducts();

            foreach (Product product in allProducts)
            {
                Console.WriteLine(product);
                Console.WriteLine("");
            }
        }
    }
}