using System;
using Models;
using System.Collections.Generic;
using DL;

namespace StoreBL
{
    public class BL : IBL
    {
        private IRepo _repo;

        public BL(IRepo repo)
        {
            _repo = repo;
        }

        public List<Customer> GetAllCustomers()
        {
            return _repo.GetAllCustomers();
        }

        public Customer AddCustomer(Customer customer)
        {
            return _repo.AddCustomer(customer);
        }

        public List<Order> GetAllOrders()
        {
            return _repo.GetAllOrders();
        }

        public Order AddOrder(Order order)
        {
            return _repo.AddOrder(order);
        }

        public List<LineItem> GetAllLineItems()
        {
            return _repo.GetAllLineItems();
        }

        public LineItem UpdateLineItem(LineItem itemToUpdate)
        {
            return _repo.UpdateLineItem(itemToUpdate);
        }
    }
}
