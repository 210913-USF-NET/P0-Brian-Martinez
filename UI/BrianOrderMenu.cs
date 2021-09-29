using System;
using System.Collections.Generic;
using Models;
using Serilog;
using StoreBL;

namespace UI
{
    public class BrianOrderMenu : IMenu
    {
        public StoreFront currentStore = BrianMenu.currentStore;
        private IBL _bl;

        public BrianOrderMenu(IBL bl)
        {
            _bl = bl;
        }

        public void Start()
        {
            List<Order> orders = _bl.GetStoreOrder(currentStore.Id);
            if (orders.Count == 0)
            {
                Console.WriteLine("No Previous Orders");
            }
            List<Order> newestOrders = _bl.GetStoreOrderNewest(currentStore.Id);
            if (orders.Count == 0)
            {
                Console.WriteLine("No Previous Orders");
            }

            bool exit = false;
            do
            {
                Console.WriteLine("[1] View Order History");
                Console.WriteLine("[2] Filter Date Newest");
                Console.WriteLine("[2] Filter Date Oldest");
                Console.WriteLine("[x] Back to Main Menu");

                switch (Console.ReadLine())
                {
                    case "1":
                        Log.Information($"Retrieving data...");
                        ViewOrderHistory(orders);
                        break;
                    case "2":
                        Log.Information($"Retrieving data...");
                        ViewOrderHistoryNewest(orders);
                        break;
                    case "3":
                        Log.Information($"Retrieving data...");
                        ViewOrderHistory(orders);
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

        public void ViewOrderHistory(List<Order> orders)
        {
            for (int i = 0; i < orders.Count; i++)
            {
                Console.WriteLine($"Order Number {i + 1}");
                List<LineItem> item = _bl.GetOrder(orders[i].Id);
                int total = 0;
                for (int j = 0; j < item.Count; j++)
                {
                    LineItem test = item[j];
                    StoreFront store = _bl.GetStore((int)test.StoreId);
                    Product product = _bl.GetProduct(test.ProductId);
                    Console.WriteLine($"Date: {orders[i].OrderDateTime} | Store: {store.Name} \nQuantity: {test.Quantity} | Name: {product.Name}");
                    total += product.Price;
                }
                Console.WriteLine($"Order total was: ${total}");
                Console.WriteLine("----------------------------------");
            }
        }

        public void ViewOrderHistoryNewest(List<Order> orders)
        {
            for (int i = 0; i < orders.Count; i++)
            {
                Console.WriteLine($"Order Number {i + 1}");
                List<LineItem> item = _bl.GetOrder(orders[i].Id);
                int total = 0;
                for (int j = 0; j < item.Count; j++)
                {
                    LineItem test = item[j];
                    StoreFront store = _bl.GetStore((int)test.StoreId);
                    Product product = _bl.GetProduct(test.ProductId);
                    Console.WriteLine($"Date: {orders[i].OrderDateTime} | Store: {store.Name} \nQuantity: {test.Quantity} | Name: {product.Name}");
                    total += product.Price;
                }
                Console.WriteLine($"Order total was: ${total}");
                Console.WriteLine("----------------------------------");
            }
        }
    }
}