using System.Collections.Generic;
using Models;
using System.IO;
using System.Text.Json;
using System;
using System.Linq;

namespace DL
{
    public class FileRepo : IRepo
    {
        private const string filePath = "../DL/Customers.json";
        private const string orderFilePath = "../DL/Orders.json";

        private string jsonString;

        public Customer AddCustomer(Customer customer)
        {
            List<Customer> allCustomers = GetAllCustomers();
            allCustomers.Add(customer);

            jsonString = JsonSerializer.Serialize(customer);
            File.WriteAllText(filePath, jsonString);
            
            return customer;
        }

        public List<Customer> GetAllCustomers()
        {
            jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Customer>>(jsonString);
        }

        public Order AddOrder(Order order)
        {
            List<Order> allOrders = GetAllOrders();
            allOrders.Add(order);

            jsonString = JsonSerializer.Serialize(order);
            File.WriteAllText(orderFilePath, jsonString);
            
            return order;
        }

        public List<Order> GetAllOrders()
        {
            jsonString = File.ReadAllText(orderFilePath);
            return JsonSerializer.Deserialize<List<Order>>(jsonString);
        }

        public List<LineItem> GetAllLineItems()
        {
            jsonString = File.ReadAllText(orderFilePath);
            return JsonSerializer.Deserialize<List<LineItem>>(jsonString);
        }

        public LineItem UpdateLineItem(LineItem itemToUpdate)
        {
            List<LineItem> allLineItems = GetAllLineItems();
            int itemIndex = allLineItems.FindIndex(o => o.Equals(itemToUpdate));

            allLineItems[itemIndex].Quantity = itemToUpdate.Quantity;
            jsonString = JsonSerializer.Serialize(allLineItems);
            return itemToUpdate;
        }
    }
}