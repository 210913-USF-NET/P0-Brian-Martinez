using System;

namespace UI
{
    public class BrianLocationMenu : IMenu
    {
        public void Start()
        {
            bool exit = false;
            do
            {
                Console.WriteLine("[1] Restock Inventory");
                Console.WriteLine("[2] View Order History");
                Console.WriteLine("[x] Back to Admin Menu");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Restocking inventory");
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
    }
}