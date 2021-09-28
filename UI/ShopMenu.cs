using System;
using System.Collections.Generic;
using Models;
using StoreBL;

namespace UI
{
    public class ShopMenu : IMenu
    {
        public Customer currentCustomer = MenuFactory.currentCustomer;
        private IBL _bl;

        public ShopMenu(IBL bl)
        {
            _bl = bl;
        }

        public void Start()
        {
            Order currentOrder = new Order();
            currentOrder = _bl.CreateCart(1);
            StoreFront selectedStore = SelectStoreFront();
            Console.WriteLine($"Welcome to {selectedStore.Name}");
            selectedStore = _bl.GetStore(selectedStore.Id);

            List<LineItem> cartList = new List<LineItem>();
            bool exit = false;
            do
            {
                Console.WriteLine("[1] Browse Items");
                Console.WriteLine("[2] View Cart");
                Console.WriteLine("[3] Checkout");
                Console.WriteLine("[x] Back to Main Menu");

                switch (Console.ReadLine())
                {
                    case "1":
                        bool shop = false;
                        while (!shop)
                        {
                            cartList.Add(SelectProduct(selectedStore.Inventory, currentOrder.Id));
                            Console.Write("Continue Shopping? [Y/N]: ");
                            string input = Console.ReadLine().ToLower();
                            if (input == "n")
                            {
                                currentOrder.LineItems = cartList;
                                shop = true;
                            }
                            DisplayCart(currentOrder.LineItems);
                        }
                        break;
                    case "2":
                        DisplayCart(currentOrder.LineItems);
                        break;
                    case "3":
                        Checkout(selectedStore, currentOrder);
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

        public StoreFront SelectStoreFront()
        {
            List<StoreFront> allStores = _bl.GetAllStores();
        pickStore:
            for (int i = 0; i < allStores.Count; i++)
            {
                Console.WriteLine($"[{i}] {allStores[i]}");
            }
            Console.Write("Please choose a location: ");
            string input = Console.ReadLine();
            int parsedInput;

            bool parseSuccess = Int32.TryParse(input, out parsedInput);

            if (parseSuccess && parsedInput >= 0 && parsedInput < allStores.Count)
            {
                StoreFront selectedStore = allStores[parsedInput];
                return selectedStore;
            }
            else
            {
                Console.WriteLine("Invalid input");
                goto pickStore;
            }
        }

        public LineItem SelectProduct(List<Inventory> storeInv, int orderId)
        {
        shop:
            for (int i = 0; i < storeInv.Count; i++)
            {
                Product product = _bl.GetProduct(storeInv[i].ProductId.GetValueOrDefault());
                Console.WriteLine($"[{i}] {product} \n{storeInv[i].Quantity} in stock\n");
            }
            Console.Write("Choose a product: ");
            string input = Console.ReadLine();
            int parsedInput;

            bool parseSuccess = Int32.TryParse(input, out parsedInput);
            if (parseSuccess && parsedInput >= 0 && parsedInput < storeInv.Count)
            {
                Product selectedProduct = _bl.GetProduct((int)storeInv[parsedInput].ProductId);

            quantity:
                System.Console.Write("Quantity: ");
                string quantity = Console.ReadLine();
                int parsedQuantity;
                bool parseSuccess2 = Int32.TryParse(quantity, out parsedQuantity);
                if (parseSuccess2 && parsedQuantity >= 0 && parsedQuantity <= storeInv[parsedInput].Quantity)
                {
                    LineItem itemToAdd = new LineItem((int)storeInv[parsedInput].StoreId, selectedProduct.Id, parsedQuantity, orderId);
                    return itemToAdd;
                }
                else
                {
                    System.Console.WriteLine("We do not have that many in stock");
                    goto quantity;
                }
            }
            else
            {
                Console.WriteLine("Invalid Input");
                goto shop;
            }
        }

        public void DisplayCart(List<LineItem> cart)
        {
            int total = 0;
            foreach (LineItem item in cart)
            {
                Product product = _bl.GetProduct(item.ProductId);
                Console.WriteLine($"{product.Name} | Quantity: {item.Quantity}");
                total += (int)((product.Price) * item.Quantity);
            }
            System.Console.WriteLine($"Total: ${total}");
        }

        public void Checkout(StoreFront store, Order order)
        {
        checkout:
            Console.Write("Confrim Checkout [Y/N]: ");
            string input = Console.ReadLine().ToLower();
            if (input == "y")
            {
                _bl.PlaceOrder(order, store);
                foreach (LineItem item in order.LineItems)
                {
                    _bl.UpdateInventory(store, item);
                }
            }
            else
            {
                goto checkout;
            }
        }
    }
}