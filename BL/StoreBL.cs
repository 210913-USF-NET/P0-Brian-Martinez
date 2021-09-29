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

        public Order CreateCart(int customerId, int StoreId)
        {
            return _repo.CreateCart(customerId, StoreId);
        }

        public Product AddProduct(Product product)
        {
            return _repo.AddProduct(product);
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
        public int AddInventory(int inventory, int restock)
        {
            return _repo.AddInventory(inventory, restock);
        }

        public List<Order> GetCustomerOrder(int CustomerId)
        {
            return _repo.GetCustomerOrder(CustomerId);
        }
        public List<Order> GetCustomerOrderNewest(int CustomerId)
        {
            return _repo.GetCustomerOrderNewest(CustomerId);
        }
        public List<Order> GetStoreOrder(int StoreId)
        {
            return _repo.GetStoreOrder(StoreId);
        }
        public List<Order> GetStoreOrderNewest(int StoreId)
        {
            return _repo.GetStoreOrderNewest(StoreId);
        }

        public List<LineItem> GetOrder(int Id)
        {
            return _repo.GetOrder(Id);
        }
    }
}