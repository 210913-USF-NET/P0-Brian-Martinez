using System;
using StoreBL;
using System.Collections.Generic;
using Models;

namespace UI
{
    public class ShopChooseLocationMenu : IMenu
    {
        private IBL _bl;

        public ShopChooseLocationMenu(IBL bl)
        {
            _bl = bl;
        }

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
                Console.WriteLine("[x] Back to Main Menu");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("You are now viewing Cherry Hill's location");
                        PlaceOrder();
                        break;
                    case "2":
                        Console.WriteLine("You are now viewing Downtown's location");
                        PlaceOrder();
                        break;
                    case "3":
                        Console.WriteLine("You are now viewing Seaside's location");
                        PlaceOrder();
                        break;
                    case "4":
                        Console.WriteLine("You are now viewing Mount Pine's location");
                        PlaceOrder();
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

        private void PlaceOrder()
        {
            Console.WriteLine("Please select a product to purchase");
        }
    }
}
            // itemStart:
            // Console.WriteLine("Please select the product you would like to buy");
            // List<LineItem> allLineItems = _bl.GetAllLineItems();
            // for (int i = 0; i < allLineItems.Count; i++)
            // {
            //     Console.WriteLine($"[{i}] {allLineItems[i]}");
            // }
            // string input = Console.ReadLine();
            // int parsedInput;

            // bool parseSuccess = Int32.TryParse(input, out parsedInput);

            // if(parseSuccess && parsedInput >= 1 && parsedInput < allLineItems.Count)
            // {
            //     LineItem selectedLineItem = allLineItems[parsedInput];

            //     LineItem itemToAdd = new LineItem();
            //     quantity:
            //     Console.Write("How many?: ");
            //     int orderQuantity;
            //     bool success = Int32.TryParse(Console.ReadLine(), out orderQuantity);

            //     if (!success) 
            //     {
            //         Console.WriteLine("Invalid input");
            //         goto quantity;
            //     }
            //     try 
            //     {
            //         itemToAdd.Quantity = orderQuantity;
            //     }
            //     catch (Exception e)
            //     {
            //         Console.WriteLine(e.Message);
            //     }
            //     selectedLineItem.Order.Add(itemToAdd);
            //     LineItem updatedLineItem = _bl.UpdatedInventory(selectedLineItem);

            //     foreach (LineItem item in updatedLineItem.Quantity)
            //     {
            //         Console.WriteLine(item);
            //     }
            // }
            // else
            // {
            //     Console.WriteLine("Invalid Input");
            //     goto itemStart;
            // }