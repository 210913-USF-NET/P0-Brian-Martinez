using System;
using StoreBL;
using DL;
using DL.Entities;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace UI
{
    public class MenuFactory
    {
        public static IMenu GetMenu(string menuString)
        {
            string connectionString = File.ReadAllText(@"../connectionString.txt");
            DbContextOptions<P0BrianMartinezDBContext> options = new DbContextOptionsBuilder<P0BrianMartinezDBContext>().UseSqlServer(connectionString).Options;
            P0BrianMartinezDBContext context = new P0BrianMartinezDBContext(options);

            switch (menuString.ToLower())
            {
                case "main":
                    return new MainMenu(new BL(new DBRepo(context)));
                case "customer":
                    return new CustomerMenu(new BL(new DBRepo(context)));
                case "brian":
                    return new BrianMenu(new BL(new DBRepo(context)));
                case "shop":
                    return new ShopMenu(new BL(new DBRepo(context)));
                case "brianmanage":
                    return new BrianLocationMenu(new BL(new DBRepo(context)));
                case "order":
                    return new OrderMenu(new BL(new DBRepo(context)));
                default:
                    return null;
            }
        }
    }
}