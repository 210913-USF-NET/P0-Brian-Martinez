using System;
using Models;
using StoreBL;
using DL;
using System.Collections.Generic;
using Serilog;

namespace UI
{
    public class MainMenu : IMenu
    {
        public static Customer currentCustomer;

        private IBL _bl;

        public MainMenu(IBL bl)
        {
            _bl = bl;
        }

        public void Start()
        {
            Console.WriteLine("*****************************************\n");
            Console.WriteLine("Welcome to The Beer Garden's console app!");
            Console.WriteLine("         must be 21 to enter\n");
            Console.WriteLine("*****************************************\n");
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
                        MenuFactory.GetMenu("customer").Start();
                        break;
                    case "2":
                        SearchLastName();
                        MenuFactory.GetMenu("customer").Start();
                        break;
                    case "x":
                        Console.WriteLine("Bye!");
                        exit = true;
                        break;
                    case "brian":
                        MenuFactory.GetMenu("brian").Start();
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

            if (age < 21)
            {
                Console.WriteLine("Grow up kid");
                Environment.Exit(0);
            }
            else
            {
                Customer newCustomer = new Customer(firstname, lastname, age);
                Customer addedCustomer = _bl.AddCustomer(newCustomer);
                currentCustomer = addedCustomer;
                Log.Information($"Customer: {currentCustomer} successfully added");
            }
        }

        private void SearchLastName()
        {
        login:
            Console.Write("Enter last name: ");
            List<Customer> searchResult = _bl.SearchCustomer(Console.ReadLine());
            if (searchResult == null || searchResult.Count == 0)
            {
                Console.WriteLine("No Existing Members with that name");
                goto login;
            }
            for (int i = 0; i < searchResult.Count; i++)
            {
                Console.WriteLine($"[{i}] {searchResult[i]}");
            }
            string input = Console.ReadLine();
            int parsedInput;

            bool parseSuccess = Int32.TryParse(input, out parsedInput);

            if (parseSuccess && parsedInput >= 0 && parsedInput < searchResult.Count)
            {
                Customer selectedCustomer = searchResult[parsedInput];
                currentCustomer = selectedCustomer;
                Console.WriteLine(currentCustomer.Id);
                Console.WriteLine($"Welcome back {selectedCustomer.FirstName}!");
            }
        }
    }
}