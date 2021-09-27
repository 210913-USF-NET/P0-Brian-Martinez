namespace Models
{
    public class LineItem
    {
        public LineItem() {}

        public LineItem(Product item) : this()
        {
            this.Item = item;
        }

        public LineItem(Product item, int quantity) : this(item)
        {
            this.Quantity = quantity;
        }

        public Product Item {get; set;}
        public int Quantity {get; set;}

        public override string ToString()
        {
            return $"{this.Quantity} {this.Item}(s) added to cart";
        }
    }
}