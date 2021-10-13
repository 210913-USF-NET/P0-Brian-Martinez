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
            List<Customer> allCustos = _context.Customers.AsNoTracking().Select(
                customer => new Customer()
                {
                    Id = customer.Id,
                    Username = customer.Username,
                    Password = customer.Password,
                    Age = customer.Age
                }
            ).ToList();

            allCustos = allCustos.OrderBy(x => x.Id).ToList();
            return allCustos;
        }

        /// <summary>
        /// gooes through the DB's list of customers, and finds the customer with taken Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// updates customer's variables
        /// </summary>
        /// <param name="customerToUpdate"></param>
        /// <returns></returns>
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
        /// edits the quantity of the lineitem in the cart
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public LineItem UpdateLineItem(LineItem item)
        {
            LineItem itemToUpdate = new LineItem()
            {
                StoreId = item.StoreId,
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                OrderId = item.OrderId
            };

            itemToUpdate = _context.LineItems.Update(itemToUpdate).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return itemToUpdate;
        }

        /// <summary>
        /// returns list of customers where parameter equals last name 
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

        /// <summary>
        /// searches through customers for one with matching username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
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

        /// <summary>
        /// creates shopping cart with a customer's Id
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns></returns>
        public Order CreateCart(int CustomerId)
        {
            // Entity.Order cart = new Entity.Order() { };
            // cart.CustomerId = CustomerId;
            Order cart = new Order()
            {
                CustomerId = CustomerId
            };
            cart = _context.Add(cart).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Order()
            {
                Id = cart.Id,
                CustomerId = (int)cart.CustomerId,
            };
        }

        /// <summary>
        /// places cart with lineitems to the DB
        /// </summary>
        /// <param name="order"></param>
        /// <param name="store"></param>
        /// <returns></returns>
        public Order PlaceOrder(Order order, StoreFront store)
        {
            DateTime now = DateTime.Now;
            /*System.Diagnostics.Debug.WriteLine(now);*/
            Order newOrder = new Order()
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                LineItems = order.LineItems,
                OrderDateTime = now
            };

            _context.Update(newOrder);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return newOrder;
        }

        public List<Order> GetCustomerOrder(int CustomerId)
        {
            return _context.Orders.Where(o => o.CustomerId == CustomerId).Select(newOrder => new Order()
            {
                Id = newOrder.Id,
                CustomerId = newOrder.CustomerId,
                OrderDateTime = newOrder.OrderDateTime
            }).ToList();
        }

        public List<Order> GetCustomerOrderNewest(int CustomerId)
        {
            List<Order> newestOrders = _context.Orders.Where(o => o.CustomerId == CustomerId).Select(newOrder => new Order()
            {
                Id = newOrder.Id,
                CustomerId = newOrder.CustomerId,
                OrderDateTime = newOrder.OrderDateTime
            }).ToList();

            newestOrders = newestOrders.OrderBy(x => x.OrderDateTime).ToList();
            return newestOrders;
        }

        public List<Order> GetCustomerOrderOldest(int CustomerId)
        {
            List<Order> newestOrders = _context.Orders.Where(o => o.CustomerId == CustomerId).Select(newOrder => new Order()
            {
                Id = newOrder.Id,
                CustomerId = newOrder.CustomerId,
                OrderDateTime = newOrder.OrderDateTime
            }).ToList();

            newestOrders = newestOrders.OrderByDescending(x => x.OrderDateTime).ToList();
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
            List<Product> allProducts = _context.Products.Select(
            product => new Product()
            {
                Id = product.Id,
                Name = product.Name,
                Price = (int)product.Price,
                Description = product.Description
            }
            ).ToList();

            allProducts = allProducts.OrderBy(x => x.Id).ToList();
            return allProducts;
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
            };
        }

        public StoreFront GetStore(int ID)
        {
            /*Include(s => s.Inventory)*/
            StoreFront getStore = _context.StoreFronts.Include(s => s.Inventory).FirstOrDefault(s => s.Id == ID);
            return new StoreFront()
            {
                Id = getStore.Id,
                Name = getStore.Name,
                Inventory = getStore.Inventory
            };
        }

        public Inventory GetInventoryById(int StoreId, int ProductId)
        {
            Inventory getInventory = _context.Inventories.FirstOrDefault(i => i.StoreId == StoreId &&  i.ProductId == ProductId);

            return new Inventory()
            {
                Id = getInventory.Id,
                StoreId = getInventory.StoreId,
                ProductId = getInventory.ProductId,
                Quantity =getInventory.Quantity
            };
        }

        public Inventory GetInventoryById(int Id)
        {
            Inventory getInventory = _context.Inventories.FirstOrDefault(i => i.Id == Id);

            return new Inventory()
            {
                Id = getInventory.Id,
                StoreId = getInventory.StoreId,
                ProductId = getInventory.ProductId,
                Quantity = getInventory.Quantity
            };
        }

        public List<Inventory> GetInventory()
        {
            List<Inventory> allInv = _context.Inventories.Select(
                Inventory => new Inventory()
                {
                    Id = Inventory.Id,
                    StoreId = Inventory.StoreId,
                    ProductId = Inventory.ProductId,
                    Quantity = Inventory.Quantity
                }
            ).ToList();

            allInv = allInv.OrderBy(x => x.Id).ToList();
            return allInv;
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

        public Inventory AddInventory(Inventory updateInv)
        {
            Inventory test = new Inventory()
            {
                Id = updateInv.Id,
                StoreId = updateInv.StoreId,
                ProductId = updateInv.ProductId,
                Quantity = updateInv.Quantity
            };

            test = _context.Inventories.Update(test).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Inventory()
            {
                Id = test.Id,
                StoreId = test.StoreId,
                ProductId = test.ProductId,
                Quantity = test.Quantity
            };
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