using System;
using Models;
using StoreBL;
using DL;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Welcome to Brian's Store!");
            Console.WriteLine("");
            Console.WriteLine("--------------------------------------------------");
            
            new MainMenu(new BL(new ExampleRepo()));
        }
    }
}
