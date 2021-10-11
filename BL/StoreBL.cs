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

        public Customer GetCustomerById(int Id)
        {
            return _repo.GetCustomerById(Id);
        }
        
        public Customer UpdateCustomer(Customer customerToUpdate)
        {
            return _repo.UpdateCustomer(customerToUpdate);
        }

        public List<Customer> SearchCustomer(string username, string password)
        {
            return _repo.SearchCustomer(username, password);
        }
        public List<Customer> Search(string username)
        {
            return _repo.Search(username);
        }

        public void RemoveCustomer(int Id)
        {
            _repo.RemoveCustomer(Id);
        }

        public List<StoreFront> GetAllStores()
        {
            return _repo.GetAllStores();
        }
        public StoreFront AddStore(StoreFront store)
        {
            return _repo.AddStore(store);
        }
        public StoreFront GetStore(int Id)
        {
            return _repo.GetStore(Id);
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

        public Inventory GetInventoryById(int StoreId, int ProductId)
        {
            return _repo.GetInventoryById(StoreId, ProductId);
        }

        public Inventory CreateInventory(Inventory inventory)
        {
            return _repo.CreateInventory(inventory);
        }
    }
}