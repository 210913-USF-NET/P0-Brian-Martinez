using System;
using System.Collections.Generic;

namespace Models
{
    public class Order
    {
        public Order()
        {
            this.OrderDateTime = DateTime.Now;
        }
        public Order(int StoreId, int OrderId, int CustomerId, List<LineItem> lineItems) : this()
        {
            this.Id = OrderId;
            this.StoreId = StoreId;
            this.CustomerId = CustomerId;
            this.LineItems = lineItems;
        }

        public int Id { get; set; }
        public int StoreId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime OrderDateTime { get; set; }
        public LineItem LineItem { get; set; }
        public List<LineItem> LineItems { get; set; }

        public override string ToString()
        {
            return $"ID: {Id} | CustomerId: {CustomerId}";
        }
    }
}