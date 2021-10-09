using Models;
using System.Collections.Generic;
using DL;

namespace StoreBL
{
    public interface IBL
    {
        //Customers
        Customer AddCustomer(Customer customer);
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(int Id);
        Customer UpdateCustomer(Customer customerToUpdate);
        void RemoveCustomer(int Id);
        List<Customer> SearchCustomer(string username, string password);
        List<Customer> Search(string username);

        //StoreFronts
        StoreFront AddStore(StoreFront store);
        List<StoreFront> GetAllStores();
        StoreFront GetStore(int Id);

        //Orders
        Order CreateCart(int customerId, int StoreId);
        Order PlaceOrder(Order order, StoreFront store);
        List<Order> GetCustomerOrder(int CustomerId);
        List<Order> GetStoreOrder(int StoreId);
        List<Order> GetCustomerOrderNewest(int CustomerId);
        List<Order> GetStoreOrderNewest(int StoreId);
        List<LineItem> GetOrder(int Id);


        List<Product> GetProducts();
        Product AddProduct(Product product);

        Product GetProduct(int Id);
        List<Inventory> GetInventory();
        int UpdateInventory(StoreFront store, LineItem item);
        int AddInventory(int inventory, int restock);

        Inventory CreateInventory(Inventory inventory);
    }
}