using System.Collections.Generic;

namespace Models
{
    public class Order
    {
        public List<LineItem> LineItems {get; set;}
        public decimal Total {get; set;}

        public override string ToString()
        {
            return $"{this.LineItems} | TOTAL: ${this.Total}"; 
        }
    }
}