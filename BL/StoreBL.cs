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

        // public Customer UpdateCustomer(Customer customerToUpdate)
        // {
        //     return _repo.UpdateCustomer(customerToUpdate);
        // }

        public List<Customer> SearchCustomer(string queryStr)
        {
            return _repo.SearchCustomer(queryStr);
        }

        public List<StoreFront> GetAllStores()
        {
            return _repo.GetAllStores();
        }

        public List<Order> GetAllOrders()
        {
            return _repo.GetAllOrders();
        }

        public Order AddOrder(Order order)
        {
            return _repo.AddOrder(order);
        }

        public List<Product> GetProducts()
        {
            return _repo.GetProducts();
        }
        public List<Inventory> GetInventory()
        {
            return _repo.GetInventory();
        }

        public Inventory UpdateInventory(Inventory productToUpdate)
        {
            return _repo.UpdateInventory(productToUpdate);
        }
    }
}
