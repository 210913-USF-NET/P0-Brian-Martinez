using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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

        public Models.StoreFront AddStore(Models.StoreFront store)
        {
            Entity.StoreFront storeToAdd = new Entity.StoreFront()
            {
                Name = store.Name
            };

            storeToAdd = _context.Add(storeToAdd).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Models.StoreFront()
            {
                Id = storeToAdd.Id,
                Name = storeToAdd.Name,
            };
        }

        public Models.Product AddProduct(Models.Product product)
        {
            Entity.Product productToAdd = new Entity.Product()
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description
            };

            productToAdd = _context.Add(productToAdd).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Models.Product()
            {
                Id = productToAdd.Id,
                Name = productToAdd.Name,
                Price = (int)productToAdd.Price,
                Description = productToAdd.Description
            };
        }

        public Models.Order CreateCart(int CustomerId)
        {
            // Entity.Order cart = new Entity.Order() { };
            // cart.CustomerId = CustomerId;
            Entity.Order cart = new Entity.Order()
            {
                CustomerId = CustomerId
            };
            cart = _context.Add(cart).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Models.Order()
            {
                Id = cart.Id,
                CustomerId = (int)cart.CustomerId
            };
        }

        public Models.Order PlaceOrder(Models.Order order, Models.StoreFront store)
        {
            foreach (Models.LineItem item in order.LineItems)
            {
                Entity.LineItem itemToAdd = new Entity.LineItem()
                {
                    StoreId = store.Id,
                    ProductId = item.ProductId,
                    Quantity = (int)item.Quantity,
                    OrderId = order.Id
                };
                itemToAdd = _context.Add(itemToAdd).Entity;
                _context.SaveChanges();
                _context.ChangeTracker.Clear();
            }

            return order;
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
                    Price = (int)product.Price,
                    Description = product.Description
                }
            ).ToList();
        }

        public Models.Product GetProduct(int Id)
        {
            Entity.Product getProduct = _context.Products.FirstOrDefault(p => p.Id == Id);
            return new Models.Product()
            {
                Id = getProduct.Id,
                Name = getProduct.Name,
                Price = (int)getProduct.Price,
                Description = getProduct.Description,
                Inventory = getProduct.Inventories.Select(p => new Models.Inventory()
                {
                    Id = p.Id,
                    ProductId = p.ProductId,
                    Quantity = p.Quantity
                }).ToList()
            };
        }

        public Models.StoreFront GetStore(int ID)
        {
            Entity.StoreFront getStore = _context.StoreFronts.Include(s => s.Inventories).FirstOrDefault(s => s.Id == ID);

            return new Models.StoreFront()
            {
                Id = getStore.Id,
                Name = getStore.Name,
                Inventory = getStore.Inventories.Select(s => new Models.Inventory()
                {
                    Id = s.Id,
                    StoreId = s.StoreId,
                    ProductId = s.ProductId,
                    Quantity = s.Quantity
                }).ToList()
            };
        }

        public List<Models.Inventory> GetInventory()
        {
            return _context.Inventories.Select(
                Inventory => new Models.Inventory()
                {
                    Id = Inventory.Id,
                    StoreId = Inventory.StoreId,
                    ProductId = Inventory.ProductId,
                    Quantity = Inventory.Quantity
                }
            ).ToList();
        }

        public int UpdateInventory(Models.StoreFront store, Models.LineItem item)
        {
            bool itemFound = false;
            int i = 0;
            Models.Inventory test = store.Inventory.FirstOrDefault(i => i.ProductId == item.ProductId && store.Id == i.StoreId);
            Entity.Inventory updateInv = new Entity.Inventory()
            {
                Id = test.Id,
                StoreId = store.Id,
                ProductId = item.ProductId,
                Quantity = (int)(test.Quantity - item.Quantity)
            };

            updateInv = _context.Inventories.Update(updateInv).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            int newQuantity = Convert.ToInt32(updateInv.Quantity);

            return newQuantity;
        }
    }
}