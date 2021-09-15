using System;
using StoreBL;

namespace UI
{
    public class MainMenu : IMenu
    {
        public void Start()
        {
            private IBL _bl;

            public MainMenu(IBL bl)
            {
                _bl = bl;
            }

            Console.WriteLine("This is the Main Menu.");
        }
    }
}