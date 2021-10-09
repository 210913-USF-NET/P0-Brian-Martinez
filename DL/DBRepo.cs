using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Models;

namespace DL
{
    public class DBRepo : IRepo
    {
        private P1_DBContext _context;

        public DBRepo(P1_DBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// adding new customer to the database with a full name and age
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public Customer AddCustomer(Customer customer)
        {
            Customer customerToAdd = new Customer()
            {
                Username = customer.Username,
                Password = customer.Password,
                Age = customer.Age
            };

            customerToAdd = _context.Add(customerToAdd).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Customer()
            {
                Id = customerToAdd.Id,
                Username = customerToAdd.Username,
                Password = customerToAdd.Password,
                Age = customerToAdd.Age
            }; 
        }

        /// <summary>
        /// retrieves all the customers from the database in list form
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.AsNoTracking().Select(
                customer => new Customer()
                {
                    Id = customer.Id,
                    Username = customer.Username,
                    Password = customer.Password,
                    Age = customer.Age
                }
            ).ToList();
        }

        public Customer GetCustomerById(int Id)
        {
            Customer customer = _context.Customers
                .AsNoTracking()
                .FirstOrDefault(c => c.Id == Id);

            return new Customer()
            {
                Id = customer.Id,
                Username = customer.Username,
                Password = customer.Password,
                Age = customer.Age
            };
        }

        public Customer UpdateCustomer(Customer customerToUpdate)
        {
            Customer custToUpdate = new Customer()
            {
                Id = customerToUpdate.Id,
                Username = customerToUpdate.Username,
                Password = customerToUpdate.Password,
                Age = customerToUpdate.Age
            };

            custToUpdate = _context.Customers.Update(custToUpdate).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return custToUpdate;
        }

        /// <summary>
        /// returns customer or list of customers where parameter equals last name 
        /// </summary>
        /// <param name="queryStr"></param>
        /// <returns></returns>
        public List<Customer> SearchCustomer(string username, string password)
        {
            return _context.Customers.Where(
                customer => customer.Username.Contains(username) && customer.Password.Contains(password)
            ).Select(
                c => new Customer()
                {
                    Id = c.Id,
                    Username = c.Username,
                    Password = c.Password,
                    Age = c.Age
                }
            ).ToList();
        }

        public List<Customer> Search(string username)
        {
            return _context.Customers.Where(
                customer => customer.Username.Contains(username)
                ).Select(
                c => new Customer()
                {
                    Id = c.Id,
                    Username = c.Username,
                    Password = c.Password,
                    Age = c.Age
                }).ToList();
        }

        /// <summary>
        /// retrives all stores from the database
        /// </summary>
        /// <returns></returns>
        public List<StoreFront> GetAllStores()
        {
            return _context.StoreFronts.Select(
                store => new StoreFront()
                {
                    Id = store.Id,
                    Name = store.Name
                }
            ).ToList();
        }

        public StoreFront AddStore(StoreFront store)
        {
            StoreFront storeToAdd = new StoreFront()
            {
                Name = store.Name
            };

            storeToAdd = _context.Add(storeToAdd).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new StoreFront()
            {
                Id = storeToAdd.Id,
                Name = storeToAdd.Name,
                Inventory = storeToAdd.Inventory.Select(s => new Inventory()
                {
                    Id = s.Id,
                    StoreId = s.StoreId,
                    ProductId = s.ProductId,
                    Quantity = s.Quantity
                }).ToList()
            };
        }

        public Product AddProduct(Product product)
        {
            Product productToAdd = new Product()
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description
            };

            productToAdd = _context.Add(productToAdd).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Product()
            {
                Id = productToAdd.Id,
                Name = productToAdd.Name,
                Price = (int)productToAdd.Price,
                Description = productToAdd.Description
            };
        }

        public Order CreateCart(int CustomerId, int StoreId)
        {
            // Entity.Order cart = new Entity.Order() { };
            // cart.CustomerId = CustomerId;
            Order cart = new Order()
            {
                CustomerId = CustomerId,
                StoreId = StoreId,
            };
            cart = _context.Add(cart).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Order()
            {
                Id = cart.Id,
                CustomerId = (int)cart.CustomerId,
                StoreId = (int)cart.StoreId
            };
        }

        public Order PlaceOrder(Order order, StoreFront store)
        {
            foreach (LineItem item in order.LineItems)
            {
                LineItem itemToAdd = new LineItem()
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

            order.OrderDateTime = DateTime.Now;
            _context.Update(order);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return order;
        }

        public List<Order> GetCustomerOrder(int CustomerId)
        {
            return _context.Orders.Where(o => o.CustomerId == CustomerId).Select(newOrder => new Order()
            {
                Id = newOrder.Id,
                CustomerId = newOrder.CustomerId
            }).ToList();
        }

        public List<Order> GetCustomerOrderNewest(int CustomerId)
        {
            List<Order> newestOrders = _context.Orders.Where(o => o.CustomerId == CustomerId).Select(newOrder => new Order()
            {
                Id = newOrder.Id,
                CustomerId = newOrder.CustomerId
            }).ToList();

            newestOrders = newestOrders.OrderBy(x => x.OrderDateTime).ToList();
            return newestOrders;
        }

        public List<Order> GetStoreOrder(int StoreId)
        {
            return _context.Orders.Where(o => o.StoreId == StoreId).Select(newOrder => new Order()
            {
                Id = newOrder.Id,
                CustomerId = newOrder.CustomerId,
                StoreId = (int)newOrder.StoreId
            }).ToList();
        }

        public List<Order> GetStoreOrderNewest(int StoreId)
        {
            List<Order> newestOrders = _context.Orders.Where(o => o.StoreId == StoreId).Select(newOrder => new Order()
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
                    select new LineItem
                    {
                        StoreId = item.StoreId,
                        ProductId = (int)item.ProductId,
                        Quantity = item.Quantity,
                        OrderId = (int)item.OrderId
                    }).ToList();
        }

        public List<Product> GetProducts()
        {
            return _context.Products.Select(
            product => new Product()
            {
                Id = product.Id,
                Name = product.Name,
                Price = (int)product.Price,
                Description = product.Description
            }
        ).ToList();
        }

        public Product GetProduct(int Id)
        {
            Product getProduct = _context.Products.FirstOrDefault(p => p.Id == Id);
            return new Product()
            {
                Id = getProduct.Id,
                Name = getProduct.Name,
                Price = (int)getProduct.Price,
                Description = getProduct.Description,
                Inventory = getProduct.Inventory.Select(p => new Inventory()
                {
                    Id = p.Id,
                    ProductId = p.ProductId,
                    Quantity = p.Quantity
                }).ToList()
            };
        }

        public StoreFront GetStore(int ID)
        {
            StoreFront getStore = _context.StoreFronts.Include(s => s.Inventory).FirstOrDefault(s => s.Id == ID);

            return new StoreFront()
            {
                Id = getStore.Id,
                Name = getStore.Name,
                Inventory = getStore.Inventory.Select(s => new Inventory()
                {
                    Id = s.Id,
                    StoreId = s.StoreId,
                    ProductId = s.ProductId,
                    Quantity = s.Quantity
                }).ToList()
            };
        }

        public List<Inventory> GetInventory()
        {
            return _context.Inventories.Select(
                Inventory => new Inventory()
                {
                    Id = Inventory.Id,
                    StoreId = Inventory.StoreId,
                    ProductId = Inventory.ProductId,
                    Quantity = Inventory.Quantity
                }
            ).ToList();
        }

        public int UpdateInventory(StoreFront store, LineItem item)
        {
            Inventory test = store.Inventory.FirstOrDefault(i => i.ProductId == item.ProductId && store.Id == i.StoreId);
            Inventory updateInv = new Inventory()
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
            Inventory test = (from i in _context.Inventories
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

        public void RemoveCustomer(int Id)
        {
            _context.Customers.Remove(GetCustomerById(Id));
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }

        public Inventory CreateInventory(Inventory inventory)
        {
            Inventory invToAdd = new Inventory()
            {
                StoreId = inventory.StoreId,
                ProductId = inventory.ProductId,
                Quantity = inventory.Quantity
            };

            invToAdd = _context.Add(invToAdd).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Inventory()
            {
                Id = invToAdd.Id,
                StoreId = invToAdd.StoreId,
                ProductId = invToAdd.ProductId,
                Quantity = invToAdd.Quantity
            };
        }
    }
}