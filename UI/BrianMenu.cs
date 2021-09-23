using System;

namespace UI
{
    public class BrianMenu : IMenu
    {
        public void Start()
        {
            bool exit = false;
            do
            {
                Console.WriteLine("Welcome Master!");
                Console.WriteLine("[1] Manage Locations");
                Console.WriteLine("[x] Back to Main Menu");

                switch (Console.ReadLine())
                {
                    case "1":
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