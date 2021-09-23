using System;
using StoreBL;
using DL;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            new MainMenu(new BL(RAMRepo.GetInstance())).Start();
        }
    }
}
