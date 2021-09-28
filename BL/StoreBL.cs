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

        public List<Customer> SearchCustomer(string queryStr)
        {
            return _repo.SearchCustomer(queryStr);
        }

        public List<StoreFront> GetAllStores()
        {
            return _repo.GetAllStores();
        }
        public StoreFront AddStore(StoreFront store)
        {
            return _repo.AddStore(store);
        }

        public Order CreateCart(int customerId)
        {
            return _repo.CreateCart(customerId);
        }

        public List<Product> GetProducts()
        {
            return _repo.GetProducts();
        }

        public Product GetProduct(int Id)
        {
            return _repo.GetProduct(Id);
        }

        public StoreFront GetStore(int Id)
        {
            return _repo.GetStore(Id);
        }

        public List<Inventory> GetInventory()
        {
            return _repo.GetInventory();
        }

        public Order PlaceOrder(Order order, StoreFront store)
        {
            return _repo.PlaceOrder(order, store);
        }

        public int UpdateInventory(StoreFront store, LineItem item)
        {
            return _repo.UpdateInventory(store, item);
        }

        public List<LineItem> GetLineItem()
        {
            throw new NotImplementedException();
        }

        public StoreFront AddCustomer(StoreFront newStore)
        {
            throw new NotImplementedException();
        }
    }
}
