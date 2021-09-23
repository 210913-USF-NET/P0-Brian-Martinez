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

        private string jsonString;

        public Customer AddCustomer(Customer customer)
        {
            throw new System.NotImplementedException();
        }

        public List<Customer> GetAllCustomers()
        {
            jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Customer>>(jsonString);
        }
    }
}