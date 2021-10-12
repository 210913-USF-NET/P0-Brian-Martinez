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
        Order CreateCart(int customerId);
        Order PlaceOrder(Order order, StoreFront store);
        List<Order> GetCustomerOrder(int CustomerId);
        List<Order> GetCustomerOrderNewest(int CustomerId);
        List<LineItem> GetOrder(int Id);


        List<Product> GetProducts();
        Product AddProduct(Product product);

        Product GetProduct(int Id);
        List<Inventory> GetInventory();
        int UpdateInventory(StoreFront store, LineItem item);
        int AddInventory(int inventory, int restock);
        Inventory GetInventoryById(int StoreId, int ProductId);

        Inventory CreateInventory(Inventory inventory);
    }
}