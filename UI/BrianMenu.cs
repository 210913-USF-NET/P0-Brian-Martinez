using System;
using Models;
using StoreBL;
using System.Collections.Generic;
using Serilog;

namespace UI
{
    public class BrianMenu : IMenu
    {
        public static StoreFront currentStore;
        public static Customer chosenCustomer;
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
                Console.WriteLine("Welcome Mr. Martinez!");
                Console.WriteLine("[1] Manage Locations");
                Console.WriteLine("[2] View All Customers");
                Console.WriteLine("[3] View Customer Order History");
                Console.WriteLine("[4] Add Location");
                Console.WriteLine("[5] Add Product");
                Console.WriteLine("[x] Log Out");

                switch (Console.ReadLine())
                {
                    case "1":
                        MenuFactory.GetMenu("brianmanage").Start();
                        break;
                    case "4":
                        CreateStoreFront();
                        break;
                    case "5":
                        CreateProduct();
                        break;
                    case "2":
                        ViewAllCustomers();
                        break;
                    case "3":
                        Customer cust = ChooseCustomer();
                        List<Order> orders = _bl.GetCustomerOrder(cust.Id);
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
                currentStore = selectedStore;
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

        private void ViewAllCustomers()
        {
            List<Customer> allCustomers = _bl.GetAllCustomers();
            if (allCustomers.Count == 0)
            {
                Console.WriteLine("There are no existing customers");
            }
            else
            {
                foreach (Customer customer in allCustomers)
                {
                    Console.WriteLine(customer.ToString());
                }
            }
        }

        public Customer ChooseCustomer()
        {
            List<Customer> allCustomers = _bl.GetAllCustomers();
            if (allCustomers.Count == 0)
            {
                Console.WriteLine("There are no existing customers");
            }
            for (int i = 0; i < allCustomers.Count; i++)
            {
                Console.WriteLine($"[{i}] {allCustomers[i]}");
            }

        pickCustomer:
            Console.Write("Choose customer: ");
            string input = Console.ReadLine();
            int parsedInput;

            bool parseSuccess = Int32.TryParse(input, out parsedInput);

            if (parseSuccess && parsedInput >= 0 && parsedInput < allCustomers.Count)
            {
                Customer selectedCustomer = allCustomers[parsedInput];
                chosenCustomer = selectedCustomer;
                return chosenCustomer;
            }
            else
            {
                Console.WriteLine("Invalid Input");
                goto pickCustomer;
            }
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
                    total = (int)(total + (product.Price) * (test.Quantity));
                }
                Console.WriteLine($"Order total was: ${total}");
                Console.WriteLine("----------------------------------");
            }
        }
    }
}