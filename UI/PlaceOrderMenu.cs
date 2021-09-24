// using System;
// using StoreBL;
// using DL;
// using System.Collections.Generic;

// namespace UI
// {
//     public class PlaceOrderMenu : IMenu
//     {
//         private IBL _bl;

//         public PlaceOrderMenu(IBL bl)
//         {
//             _bl = bl;
//         }

//         public void Start()
//         { 
//             bool exit = false;
//             string input = "";
//             do
//             {
//                 Console.WriteLine("Select a Product:");
//                 Console.WriteLine("[1] Goose Island 312 Lemonade Shandy");
//                 Console.WriteLine("[2] Victory Twisted Monkey");
//                 Console.WriteLine("[3] Blue Point Toasted Lager");
//                 Console.WriteLine("[4] UFO White");
//                 Console.WriteLine("[x] Exit");

//                 input = Console.ReadLine();

//                 switch (input)
//                 {
//                     case "1":
//                         AddToCart();
//                         break;
//                     case "2":
//                         AddToCart();
//                         break;
//                     case "3":
//                         AddToCart();
//                         break;
//                     case "4":
//                         AddToCart();
//                         break;
//                     case "x":
//                         Console.WriteLine("Bye!");
//                         exit = true;
//                         break;
//                     case "brian":
//                         new BrianMenu().Start();
//                         break;
//                     default:
//                         Console.WriteLine("Invalid input");
//                         break;
//                 }
//             } while (!exit);
//         }

//         private void CreateCustomer()
//         {
//             Console.Write("How Many ");

//             Console.WriteLine("Creating new customer");
//             Console.Write("First Name: ");
//             string firstname = Console.ReadLine();
//             Console.Write("Last Name: ");
//             string lastname = Console.ReadLine();
//             Console.Write("Age: ");
//             int age = Convert.ToInt32(Console.ReadLine());
//             Console.Write("Email: ");
//             string email = Console.ReadLine();
//             // Console.WriteLine("Phone:");
//             // string phone = Console.ReadLine();

//             Customer newCustomer = new Customer(firstname, lastname, age, email);
//             // phone
//             _bl.AddCustomer(newCustomer);
//             Console.WriteLine(newCustomer.ToString());
//         }
//     }
// }