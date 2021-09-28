using System;
using Models;
using StoreBL;
using DL;
using System.Collections.Generic;

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
                Console.WriteLine("[x] Back to Main Menu");

                switch (Console.ReadLine())
                {
                    case "1":
                        ViewAllStoreFronts();
                        new BrianLocationMenu().Start();
                        break;
                    case "2":
                        CreateStoreFront();
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
            Console.WriteLine("Creating new storefront");
            Console.Write("Name: ");
            string name = Console.ReadLine();

            StoreFront newStore = new StoreFront(name);
            StoreFront addedStore = _bl.AddCustomer(newStore);
            Console.WriteLine(addedStore.ToString());
        }
    }
}