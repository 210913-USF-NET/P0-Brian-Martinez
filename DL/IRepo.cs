using Models;
using System.Collections.Generic;

namespace DL
{
    public interface IRepo
    {
        Customer AddCustomer(Customer customer);
        List<Customer> GetAllCustomers();

        Order AddOrder(Order order);
        List<Order> GetAllOrders();

        List<LineItem> GetAllLineItems();
        LineItem UpdateLineItem(LineItem itemToUpdate);
    }
}