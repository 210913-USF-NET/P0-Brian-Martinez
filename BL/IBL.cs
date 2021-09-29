using Models;
using System.Collections.Generic;
using DL;

namespace StoreBL
{
    public interface IBL
    {
        List<Customer> GetAllCustomers();
        Customer AddCustomer(Customer customer);
        // Customer UpdateCustomer(Order customerToUpdate);
        List<Customer> SearchCustomer(string queryStr);

        List<StoreFront> GetAllStores();
        StoreFront AddStore(StoreFront store);

        Order CreateCart(int customerId);
        Order PlaceOrder(Order order, StoreFront store);

        List<Product> GetProducts();
        Product AddProduct(Product product);
        List<Order> GetCustomerOrder(int CustomerId);
        List<LineItem> GetOrder(int Id);

        Product GetProduct(int Id);
        StoreFront GetStore(int Id);
        List<Inventory> GetInventory();
        int UpdateInventory(StoreFront store, LineItem item);
        int AddInventory(int inventory, int restock);
        StoreFront AddCustomer(StoreFront newStore);
    }
}