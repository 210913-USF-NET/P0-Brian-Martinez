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
                Console.WriteLine("[1] Shop");
                Console.WriteLine("[2] View Order(s)");
                Console.WriteLine("[3] View Locations");
                Console.WriteLine("[x] Back to Main Menu");

                switch (Console.ReadLine())
                {
                    case "1":
                        new ChooseLocationMenu().Start();
                        break;
                    case "2":
                        Console.WriteLine("View order");
                        break;
                    case "3":
                        new ChooseLocationMenu().Start();
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