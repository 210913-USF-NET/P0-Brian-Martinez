namespace Models
{
    public class Product
    {
        public string Name {get; set;}
        public double Price {get; set;}
        public string Description {get; set;}

        public override string ToString()
        {
            return $"{this.Name} | Price: ${this.Price} \n{this.Description}";
        }
    }
}