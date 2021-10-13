using Models;
using System.Collections.Generic;

namespace DL
{
    public interface IRepo
    {
        Customer AddCustomer(Customer customer);
        List<Customer> GetAllCustomers();
        List<Customer> SearchCustomer(string username, string password);
        List<Customer> Search(string username);
        Customer GetCustomerById(int Id);
        Customer UpdateCustomer(Customer customerToUpdate);
        void RemoveCustomer(int Id);

        List<StoreFront> GetAllStores();
        StoreFront AddStore(StoreFront store);
        List<Order> GetCustomerOrder(int CustomerId);
        List<Order> GetCustomerOrderNewest(int CustomerId);
        List<Order> GetCustomerOrderOldest(int CustomerId);
        List<LineItem> GetOrder(int Id);
        Order CreateCart(int customerId);
        List<Product> GetProducts();
        Product AddProduct(Product product);
        Product GetProduct(int Id);
        StoreFront GetStore(int Id);
        List<Inventory> GetInventory();

        Order PlaceOrder(Order order, StoreFront store);
        Inventory AddInventory(Inventory updateInv);
        int UpdateInventory(StoreFront store, LineItem item);
        Inventory GetInventoryById(int StoreId, int ProductId);
        Inventory GetInventoryById(int Id);
        LineItem UpdateLineItem(LineItem item);

        Inventory CreateInventory(Inventory inventory);
    }
}