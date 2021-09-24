using Models;
using System.Collections.Generic;
using DL;

namespace StoreBL
{
    public interface IBL
    {
        List<Customer> GetAllCustomers();
        Customer AddCustomer(Customer customer);

        List<Order> GetAllOrders();
        Order AddOrder(Order order);

        List<LineItem> GetAllLineItems();
        LineItem UpdateLineItem(LineItem itemToUpdate);
    }
}