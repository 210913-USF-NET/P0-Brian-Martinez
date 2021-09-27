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
                        ViewAllStoreFronts();
                        new ShopMenu(_bl).Start();
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

        private void ViewAllStoreFronts()
        {
            List<StoreFront> allStores = _bl.GetAllStores();
            if (allStores == null || allStores.Count == 0)
            {
                Console.WriteLine("No Existing Locations");
                return;
            }
            for (int i = 0; i < allStores.Count; i++)
            {
                Console.WriteLine($"[{i}] {allStores[i]}");
            }
            Console.Write("Please choose a location: ");
            string input = Console.ReadLine();
            int parsedInput;

            bool parseSuccess = Int32.TryParse(input, out parsedInput);

            if (parseSuccess && parsedInput >= 0 && parsedInput < allStores.Count)
            {
                StoreFront selectedStore = allStores[parsedInput];
                Console.WriteLine($"Welcome to {selectedStore.Name}!");
            }
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