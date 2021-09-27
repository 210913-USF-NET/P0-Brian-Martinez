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

        Order AddOrder(Order order);
        List<Order> GetAllOrders();

        List<Product> GetProducts();
        List<Inventory> GetInventory();
        Inventory UpdateInventory(Inventory productToUpdate);
    }
}