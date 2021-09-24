using System;

namespace Models
{
    public class LineItem
    {
        private int _quantity;

        public Product Item {get; set;}
        public int Quantity 
        {
            get
            {
                return _quantity;
            } 
            set
            {
                if (value > Quantity || value < 1)
                {
                    throw new Exception("Invalid Quanitity");
                }
                else
                {
                    _quantity = value;
                }
            }
        }

        public override string ToString()
        {
            return $"{this.Item} \nQuantity: {this.Quantity}";
        }
    }
}