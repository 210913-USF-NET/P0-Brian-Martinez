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
            Entity.Customer customerToAdd = new Entity.Customer()
            {
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
                customer => new Models.Customer()
                {
                    Id = customer.Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Age = customer.Age
                }
            ).ToList();
        }

        // public Models.Customer UpdateCustomer(Models.Customer customerToUpdate)
        // {
        //     // throw new NotImplementedException();
        //     Entity.Customer custToUpdate = new Entity.Customer() {
        //         Id = customerToUpdate.Id,
        //         FirstName = customerToUpdate.FirstName,
        //         LastName = customerToUpdate.LastName,
        //         Age = customerToUpdate.Age
        //     };

        //     custToUpdate = _context.Customer.Update(custToUpdate).Entity;
        //     _context.SaveChanges();
        //     _context.ChangeTracker.Clear();

        //     return new Models.Customer() {
        //         Id = custToUpdate.Id,
        //         FirstName = custToUpdate.FirstName,
        //         LastName = custToUpdate.LastName,
        //         Age = custToUpdate.Age
        //     };
        // }

        public List<Customer> SearchCustomer(string queryStr)
        {
            return _context.Customers.Where(
                customer => customer.LastName.Contains(queryStr)
            ).Select(
                c => new Models.Customer()
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Age = c.Age
                }
            ).OrderBy(c => c.FirstName).ToList();
        }

        public List<Models.StoreFront> GetAllStores()
        {
            return _context.StoreFronts.Select(
                store => new Models.StoreFront()
                {
                    Id = store.Id,
                    Name = store.Name
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

        public List<Models.Product> GetProducts()
        {
            return _context.Products.Select(
                product => new Models.Product()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Description = product.Description
                }
            ).ToList();
        }

        public List<Models.Inventory> GetInventory()
        {
            return _context.Inventories.Select(
                item => new Models.Inventory()
                {
                    Id = item.Id,
                    Quantity = item.Quantity,
                    // ProductId = item.ProductId
                }
            ).ToList();
        }

        public Models.Inventory UpdateInventory(Models.Inventory productToUpdate)
        {
            throw new NotImplementedException();
            // Entity.Inventory pToUpdate = new Entity.Inventory() {
            //     Id = productToUpdate.Id,

            // };

            // pToUpdate = _context.Inventory.Update(pToUpdate).Entity;
            // _context.SaveChanges();
            // _context.ChangeTracker.Clear();

            // return new Models.Inventory() {
            //     Id = pToUpdate.Id,

            // };
        }
    }
}