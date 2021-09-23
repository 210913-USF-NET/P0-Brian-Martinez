using System;
using System.Linq;
using System.Collections.Generic;
using Models;

namespace DL
{
    public sealed class RAMRepo : IRepo
    {
        private static RAMRepo _instance;

        private RAMRepo()
        {
            _customers = new List<Customer>()
            {
                new Customer()
                {
                    FirstName = "Brian",
                    LastName = "Martinez",
                    Age = 22,
                    State = "NY"
                }
            };
        }

        public static RAMRepo GetInstance()
        {
            if (_instance == null)
            {
                _instance = new RAMRepo();
            }
            return _instance;
        }

        private static List<Customer> _customers;

        public Customer AddCustomer(Customer customer)
        {
            _customers.Add(customer);
            return customer;
        }

        public List<Customer> GetAllCustomers()
        {
            return _customers;
        }
    }
}
