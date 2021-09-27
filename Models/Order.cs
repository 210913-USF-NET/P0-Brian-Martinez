using System.Collections.Generic;

namespace Models
{
    public class Order
    {
        // public Order() {}

        // public Order(LineItem lineitems) : this()
        // {
        //     this.LineItems = lineitems;
        // }

        // public Order(LineItem lineitems, double total) : this(lineitems)
        // {
        //     this.Total = total;
        // }

        public List<LineItem> LineItems {get; set;}
        public double Total {get; set;}

        public override string ToString()
        {
            return $"{this.LineItems} | TOTAL: ${this.Total}"; 
        }
    }
}