using System;
using StoreBL;
using System.Collections.Generic;
using Models;
using System.Linq;

namespace UI
{
    public class ShopMenu : IMenu
    {
        private IBL _bl;

        public ShopMenu(IBL bl)
        {
            _bl = bl;
        }

        public void Start()
        {
            bool exit = false;
            do
            {
                Console.WriteLine("[1] Browse Items");
                Console.WriteLine("[2] View Cart");
                Console.WriteLine("[3] Checkout");
                Console.WriteLine("[x] Back to Main Menu");

                switch (Console.ReadLine())
                {
                    case "1":
                        BrowseItems();
                        break;
                    case "2":
                        Console.WriteLine("Viewing cart");
                        break;
                    case "3":
                        Console.WriteLine("Checking out");
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

        private void BrowseItems()
        {
            List<Product> allProducts = _bl.GetProducts();
            List<Inventory> allInventory = _bl.GetInventory();

            var display = allInventory.Zip(allProducts, (p, i) => new { Product = p, Inventory = i });
            int count = 0;
            foreach (var item in display)
            {
                Console.WriteLine($"[{count}] {item.Inventory} {item.Product}\n");
                count++;
            }

            // for (int i = 0; i < allInventory.Count; i++)
            // {
            //     foreach (Product product in allProducts)
            //     {
            //         Console.WriteLine($"[{i}] {product} {allInventory[i]}");
            //     }
            // }

            Console.Write("Please choose a product: ");
            string input = Console.ReadLine();
            int parsedInput;

            bool parseSuccess = Int32.TryParse(input, out parsedInput);

            if (parseSuccess && parsedInput >= 0 && parsedInput < allInventory.Count)
            {
                Inventory selectedStore = allInventory[parsedInput];
            }
        }
    }
}
