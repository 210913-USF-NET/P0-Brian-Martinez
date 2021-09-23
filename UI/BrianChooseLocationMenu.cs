using System;

namespace UI
{
    public class BrianChooseLocationMenu : IMenu
    {
        public void Start()
        {
            bool exit = false;
            do
            {
                Console.WriteLine("Please choose a location:");
                Console.WriteLine("[1] Cherry Hill Beer Garden");
                Console.WriteLine("[2] Downtown Beer Garden");
                Console.WriteLine("[3] Seaside Beer Garden");
                Console.WriteLine("[4] Mount Pine Beer Garden");
                Console.WriteLine("[x] Back to Admin Menu");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("You are now viewing Cherry Hill's location");
                        break;
                    case "2":
                        Console.WriteLine("You are now viewing Downtown's location");
                        break;
                    case "3":
                        Console.WriteLine("You are now viewing Seaside's location");
                        break;
                    case "4":
                        Console.WriteLine("You are now viewing Mount Pine's location");
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