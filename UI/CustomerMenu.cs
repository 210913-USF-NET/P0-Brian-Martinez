using System;
using Models;
using StoreBL;

namespace UI
{
    public class CustomerMenu :IMenu
    {
        public void Start()
        {
            bool exit = false;
            do
            {
                Console.WriteLine("[0] Shop");
                Console.WriteLine("[1] View Order(s)");
                Console.WriteLine("[2] View Locations");
                Console.WriteLine("[x] Back to Main Menu");

                switch (Console.ReadLine())
                {
                    case "0":
                        Console.WriteLine("Shop");
                        break;
                    case "1":
                        Console.WriteLine("View order");
                        break;
                    case "2":
                        Console.WriteLine("view locations");
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
    }
}