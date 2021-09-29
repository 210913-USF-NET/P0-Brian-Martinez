using System.Collections.Generic;

namespace Models
{
    public class Inventory
    {
        public Inventory() { }
        public Inventory(int storeId, int productId, int quantity)
        {
            this.StoreId = storeId;
            this.ProductId = productId;
            this.Quantity = quantity;
        }

        public int Id { get; set; }
        public int? StoreId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public List<Product> Products { get; set; }

        public virtual Product Product { get; set; }
        public virtual StoreFront Store { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} | StoreId: {StoreId} | ProductId: {ProductId} | Q: {Quantity}";
        }
    }
}