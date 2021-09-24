using System;
using StoreBL;
using DL;

namespace UI
{
    public class MenuFactory
    {
        public static IMenu GetMenu(string menuString)
        {
            switch (menuString.ToLower())
            {
                case "main":
                    return new MainMenu(new BL(new FileRepo()));
                case "customer":
                    return new CustomerMenu(new BL(new FileRepo()));
                case "brian":
                    return new BrianMenu();
                default:
                    return null;
            }
        }
    }
}