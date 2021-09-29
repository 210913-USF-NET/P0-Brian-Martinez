using System.Collections.Generic;

namespace Models
{
    public class Order
    {
        public Order() { }
        public Order(int OrderId, int CustomerId, List<LineItem> lineItems)
        {
            this.Id = OrderId;
            this.CustomerId = CustomerId;
            this.LineItems = lineItems;
        }

        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public LineItem LineItem { get; set; }
        public List<LineItem> LineItems { get; set; }

        public override string ToString()
        {
            return $"ID: {Id} | CustomerId: {CustomerId}";
        }
    }
}