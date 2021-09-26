using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Entity = DL.Entities;

namespace DL
{
    public class DBRepo : IRepo
    {
        private Entity.P0BrianMartinezDBContext _context;

        public DBRepo(Entity.P0BrianMartinezDBContext context)
        {
            _context = context;
        }

        public Models.Customer AddCustomer(Models.Customer customer)
        {
            Entity.Customer customerToAdd = new Entity.Customer() {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Age = customer.Age
            };

            customerToAdd = _context.Add(customerToAdd).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Models.Customer()
            {
                Id = customerToAdd.Id,
                FirstName = customerToAdd.FirstName,
                LastName = customerToAdd.LastName,
                Age = customerToAdd.Age
            };
        }

        public List<Models.Customer> GetAllCustomers()
        {
            return _context.Customers.Select(
                customer => new Models.Customer() {
                    Id = customer.Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Age = customer.Age
                }
            ).ToList();
        }

        public Models.Order AddOrder(Models.Order order)
        {
            throw new NotImplementedException();
        }

        public List<Models.Order> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public List<Models.LineItem> GetAllLineItems()
        {
            throw new NotImplementedException();
        }

        public Models.LineItem UpdateLineItem(Models.LineItem itemToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}