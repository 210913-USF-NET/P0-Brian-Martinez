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
        List<LineItem> GetLineItem();

        Product GetProduct(int Id);
        StoreFront GetStore(int Id);
        List<Inventory> GetInventory();
        int UpdateInventory(StoreFront store, LineItem item);
        StoreFront AddCustomer(StoreFront newStore);
    }
}