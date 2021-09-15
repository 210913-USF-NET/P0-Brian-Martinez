using System;
using Models;

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
            
            StoreFront myStore = new StoreFront() {
                Name = "Cherry Hill Beer Garden",
                Address = "57 Chicago Ave, Garden City, NY"
            };

            Console.WriteLine(myStore.ToString());
            myStore.Name = Console.ReadLine();
            Console.WriteLine(myStore.ToString());
        }
    }
}
