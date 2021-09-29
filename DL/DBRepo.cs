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

        /// <summary>
        /// adding new customer to the database with a full name and age
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
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

        /// <summary>
        /// retrieves all the customers from the database in list form
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// returns customer or list of customers where parameter equals last name 
        /// </summary>
        /// <param name="queryStr"></param>
        /// <returns></returns>
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

        /// <summary>
        /// retrives all stores from the database
        /// </summary>
        /// <returns></returns>
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
                Inventory = storeToAdd.Inventories.Select(s => new Models.Inventory()
                {
                    Id = s.Id,
                    StoreId = s.StoreId,
                    ProductId = s.ProductId,
                    Quantity = s.Quantity
                }).ToList()
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

        public Models.Order CreateCart(int CustomerId, int StoreId)
        {
            // Entity.Order cart = new Entity.Order() { };
            // cart.CustomerId = CustomerId;
            Entity.Order cart = new Entity.Order()
            {
                CustomerId = CustomerId,
                StoreId = StoreId,
            };
            cart = _context.Add(cart).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Models.Order()
            {
                Id = cart.Id,
                CustomerId = (int)cart.CustomerId,
                StoreId = (int)cart.StoreId
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

        public List<Models.Order> GetCustomerOrder(int CustomerId)
        {
            return _context.Orders.Where(o => o.CustomerId == CustomerId).Select(newOrder => new Models.Order()
            {
                Id = newOrder.Id,
                CustomerId = newOrder.CustomerId
            }).ToList();
        }

        public List<Models.Order> GetCustomerOrderNewest(int CustomerId)
        {
            List<Models.Order> newestOrders = _context.Orders.Where(o => o.CustomerId == CustomerId).Select(newOrder => new Models.Order()
            {
                Id = newOrder.Id,
                CustomerId = newOrder.CustomerId
            }).ToList();

            newestOrders = newestOrders.OrderBy(x => x.OrderDateTime).ToList();
            return newestOrders;
        }

        public List<Models.Order> GetStoreOrder(int StoreId)
        {
            return _context.Orders.Where(o => o.StoreId == StoreId).Select(newOrder => new Models.Order()
            {
                Id = newOrder.Id,
                CustomerId = newOrder.CustomerId,
                StoreId = (int)newOrder.StoreId
            }).ToList();
        }

        public List<Models.Order> GetStoreOrderNewest(int StoreId)
        {
            List<Models.Order> newestOrders = _context.Orders.Where(o => o.StoreId == StoreId).Select(newOrder => new Models.Order()
            {
                Id = newOrder.Id,
                StoreId = (int)newOrder.StoreId
            }).ToList();

            newestOrders = newestOrders.OrderBy(x => x.OrderDateTime).ToList();
            return newestOrders;
        }

        public List<LineItem> GetOrder(int OrderId)
        {
            return (from item in _context.LineItems
                    where item.OrderId == OrderId
                    select new Models.LineItem
                    {
                        StoreId = item.StoreId,
                        ProductId = (int)item.ProductId,
                        Quantity = item.Quantity,
                        OrderId = (int)item.OrderId
                    }).ToList();
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

        public int AddInventory(int updateInv, int restock)
        {
            Entity.Inventory test = (from i in _context.Inventories
                                     where i.Id == updateInv
                                     select i).SingleOrDefault();

            test.Quantity = test.Quantity + restock;

            //grab row in inv db alter row then save row
            // Entity.Inventory restockInv = new Entity.Inventory()
            // {
            //     Id = updateInv.Id,
            //     StoreId = updateInv.StoreId,
            //     ProductId = updateInv.ProductId,
            //     Quantity = (int)updateInv.Quantity + restock
            // };

            test = _context.Inventories.Update(test).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            int restockQuantity = Convert.ToInt32(test.Quantity);

            return restockQuantity;
        }
    }
}