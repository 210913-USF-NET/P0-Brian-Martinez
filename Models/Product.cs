namespace Models
{
    public class Product
    {
        public Product() {}

        public Product(string name) : this()
        {
            this.Name = name;
        }

        public Product(string name, double price) : this(name)
        {
            this.Price = price;
        }

        public Product(string name, double price, string description) : this(name, price)
        {
            this.Description = description;
        }

        public string Name {get; set;}
        public double Price {get; set;}
        public string Description {get; set;}

        public override string ToString()
        {
            return $"{this.Name} | Price: ${this.Price} \n{this.Description}";
        }
    }
}