using System;

namespace Models
{
    public class LineItem
    {
        public Product Item {get; set;}
        public int Quantity {get; set;}

        public override string ToString()
        {
            return $"{this.Quantity} {this.Item}(s) added to cart";
        }
    }
}