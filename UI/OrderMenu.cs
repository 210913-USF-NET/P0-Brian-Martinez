using System;
using System.Collections.Generic;
using Models;
using StoreBL;

namespace UI
{
    public class OrderMenu : IMenu
    {
        public Customer currentCustomer = MainMenu.currentCustomer;
        private IBL _bl;

        public OrderMenu(IBL bl)
        {
            _bl = bl;
        }

        public void Start()
        {
            bool exit = false;
            do
            {
                Console.WriteLine("[1] View Order History");
                Console.WriteLine("[2] Filter Price (High - Low)");
                Console.WriteLine("[2] Filter Price (Low - High)");
                Console.WriteLine("[x] Back to Main Menu");

                switch (Console.ReadLine())
                {
                    case "1":
                        ViewCustomerOrder(currentCustomer.Id);
                        break;
                    case "2":
                        ViewCustomerOrder(currentCustomer.Id);
                        break;
                    case "3":
                        ViewCustomerOrder(currentCustomer.Id);
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

        public void ViewCustomerOrder(int CustomerId)
        {
            List<Order> orders = _bl.GetCustomerOrder(CustomerId);
            if (orders.Count == 0)
            {
                Console.WriteLine("No Previous Orders");
            }
            for (int i = 0; i < orders.Count; i++)
            {
                Console.WriteLine($"Order Number {i + 1}");
                List<LineItem> item = _bl.GetOrder(orders[i].Id);
                int total = 0;
                for (int j = 0; j < item.Count; j++)
                {
                    LineItem test = item[j];
                    Product product = _bl.GetProduct(test.ProductId);
                    Console.WriteLine($"Quantity: {test.Quantity} Name: {product.Name}");
                    total += product.Price;
                }
                Console.WriteLine($"Order total was: ${total}");
                Console.WriteLine("----------------------------------");
            }
        }
    }
}