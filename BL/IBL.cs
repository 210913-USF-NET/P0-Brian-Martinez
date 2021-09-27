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

        List<Order> GetAllOrders();
        Order AddOrder(Order order);

        List<Product> GetProducts();
        List<Inventory> GetInventory();
        Inventory UpdateInventory(Inventory productToUpdate);
    }
}