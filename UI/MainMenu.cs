using System;
using Models;
using StoreBL;
using DL;
using System.Collections.Generic;

namespace UI
{
    public class MainMenu : IMenu
    {
        private IBL _bl;

        public MainMenu(IBL bl)
        {
            _bl = bl;
        }

        public void Start()
        { 
            Console.WriteLine("Welcome to The Beer Garden's console app!");
            bool exit = false;
            string input = "";
            do
            {
                Console.WriteLine("[1] Create Account");
                Console.WriteLine("[2] Existing Member");
                Console.WriteLine("[x] Exit");

                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateCustomer();
                        new CustomerMenu(new BL(new FileRepo())).Start();
                        break;
                    case "2":
                        ViewAllCustomers();
                        break;
                    case "x":
                        Console.WriteLine("Bye!");
                        exit = true;
                        break;
                    case "brian":
                        new BrianMenu().Start();
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            } while (!exit);
        }

        private void CreateCustomer()
        {
            Console.WriteLine("Creating new customer");
            Console.Write("First Name: ");
            string firstname = Console.ReadLine();
            Console.Write("Last Name: ");
            string lastname = Console.ReadLine();
            Console.Write("Age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Email: ");
            string email = Console.ReadLine();
            // Console.WriteLine("Phone:");
            // string phone = Console.ReadLine();

            Customer newCustomer = new Customer(firstname, lastname, age, email);
            // phone
            _bl.AddCustomer(newCustomer);
            Console.WriteLine(newCustomer.ToString());
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
    }
}