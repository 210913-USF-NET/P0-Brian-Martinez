using System;
using Models;
using StoreBL;
using System.Collections.Generic;
using Serilog;

namespace UI
{
    public class BrianMenu : IMenu
    {
        private IBL _bl;

        public BrianMenu(IBL bl)
        {
            _bl = bl;
        }

        public void Start()
        {
            bool exit = false;
            do
            {
                Console.WriteLine("Welcome Master!");
                Console.WriteLine("[1] Manage Locations");
                Console.WriteLine("[2] Add Location");
                Console.WriteLine("[3] Add Product");
                Console.WriteLine("[x] Back to Main Menu");

                switch (Console.ReadLine())
                {
                    case "1":
                        ViewAllStoreFronts();
                        MenuFactory.GetMenu("brianManage").Start();
                        break;
                    case "2":
                        CreateStoreFront();
                        break;
                    case "3":
                        CreateProduct();
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

        private void CreateStoreFront()
        {
            Log.Information("Creating new storefront");
            Console.Write("Name: ");
            string name = Console.ReadLine();

            StoreFront newStore = new StoreFront(name);
            StoreFront addedStore = _bl.AddStore(newStore);
            Log.Information($"Store: {addedStore.Name} successfully added");
        }

        private void CreateProduct()
        {
            Log.Information("Creating new product");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Price: ");
            int price = Convert.ToInt32(Console.ReadLine());
            Console.Write("Description: ");
            string description = Console.ReadLine();

            Product newProduct = new Product(name, price, description);
            Product addedProduct = _bl.AddProduct(newProduct);
            Log.Information($"Product: {addedProduct.Name} successfully added");
        }
    }
}