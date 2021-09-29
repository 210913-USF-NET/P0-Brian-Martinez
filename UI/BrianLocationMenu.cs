using System;
using System.Collections.Generic;
using Models;
using StoreBL;

namespace UI
{
    public class BrianLocationMenu : IMenu
    {
        private IBL _bl;

        public BrianLocationMenu(IBL bl)
        {
            _bl = bl;
        }
        public void Start()
        {
            StoreFront selectedStore = SelectStoreFront();
            Console.WriteLine($"Managing {selectedStore.Name}");
            selectedStore = _bl.GetStore(selectedStore.Id);
            bool exit = false;
            do
            {
                Console.WriteLine("[1] Restock Inventory");
                Console.WriteLine("[2] View Order History");
                Console.WriteLine("[x] Back to Admin Menu");

                switch (Console.ReadLine())
                {
                    case "1":
                        RestockInventory(selectedStore);
                        break;
                    case "2":
                        Console.WriteLine("Viewing order history");
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

        public StoreFront SelectStoreFront()
        {
            List<StoreFront> allStores = _bl.GetAllStores();
        pickStore:
            for (int i = 0; i < allStores.Count; i++)
            {
                Console.WriteLine($"[{i}] {allStores[i]}");
            }
            Console.Write("Please choose a location: ");
            string input = Console.ReadLine();
            int parsedInput;

            bool parseSuccess = Int32.TryParse(input, out parsedInput);

            if (parseSuccess && parsedInput >= 0)
            {
                StoreFront selectedStore = allStores[parsedInput];
                return selectedStore;
            }
            else
            {
                Console.WriteLine("Invalid input");
                goto pickStore;
            }
        }

        public void RestockInventory(StoreFront store)
        {
            for (int i = 0; i < store.Inventory.Count; i++)
            {
                Product product = _bl.GetProduct(store.Inventory[i].ProductId.GetValueOrDefault());
                Console.WriteLine($"[{store.Inventory[i].Id}] {product.Name} \n{store.Inventory[i].Quantity} in stock\n");
            }

            // Console.WriteLine(store.Inventory[2].ToString());
            // pickProduct:
            Console.Write("Choose a product to restock: ");
            string input = Console.ReadLine();
            int parsedInput;
            bool parseSuccess = Int32.TryParse(input, out parsedInput);

            // if (parseSuccess && parsedInput >= 0 && parsedInput < store.Inventory.Count)
            // {
            Console.WriteLine(parsedInput);
            Console.Write("Restock quantity: ");
            int restock = Convert.ToInt32(Console.ReadLine());
            _bl.AddInventory(parsedInput, restock);
            // }
            // else
            // {
            //     Console.WriteLine("Invalid input");
            //     goto pickProduct;
            // }
        }
    }
}