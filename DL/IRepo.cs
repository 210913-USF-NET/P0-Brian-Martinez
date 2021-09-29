using Models;
using System.Collections.Generic;

namespace DL
{
    public interface IRepo
    {
        Customer AddCustomer(Customer customer);
        List<Customer> GetAllCustomers();
        List<Customer> SearchCustomer(string queryStr);

        List<StoreFront> GetAllStores();
        StoreFront AddStore(StoreFront store);
        List<Order> GetCustomerOrder(int CustomerId);
        List<LineItem> GetOrder(int Id);
        Order CreateCart(int customerId);
        List<Product> GetProducts();
        Product AddProduct(Product product);
        Product GetProduct(int Id);
        StoreFront GetStore(int Id);
        List<Inventory> GetInventory();

        Order PlaceOrder(Order order, StoreFront store);
        int AddInventory(int inventory, int restock);
        int UpdateInventory(StoreFront store, LineItem item);
    }
}