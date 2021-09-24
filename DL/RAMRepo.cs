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
                    Email = "brian@gmail.com"
                }
            };

            _orders = new List<Order>()
            {
                new Order()
                {

                }
            };

            _lineItems = new List<LineItem>()
            {
                new LineItem()
                {

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

        private static List<Order> _orders;

        public Order AddOrder(Order order)
        {
            _orders.Add(order);
            return order;
        }

        public List<Order> GetAllOrders()
        {
            return _orders;
        }

        private static List<LineItem> _lineItems;

        public List<LineItem> GetAllLineItems()
        {
            return _lineItems;
        }

        public LineItem UpdateLineItem(LineItem itemToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
