using System.Collections.Generic;

namespace Models
{
    public class Product
    {
        public Product() { }

        public Product(string name) : this()
        {
            this.Name = name;
        }

        public Product(string name, decimal price) : this(name)
        {
            this.Price = price;
        }

        public Product(string name, decimal price, string description) : this(name, price)
        {
            this.Description = description;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public List<Inventory> Inventory { get; set; }

        public override string ToString()
        {
            return $"{this.Name} | Price: ${this.Price} \n{this.Description}";
        }
    }
}