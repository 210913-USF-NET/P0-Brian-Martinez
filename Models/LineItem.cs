namespace Models
{
    public class LineItem
    {
        public LineItem() { }

        public LineItem(int StoreId, int ProductId, int Quantity, int OrderId)
        {
            this.StoreId = StoreId;
            this.ProductId = ProductId;
            this.Quantity = Quantity;
            this.OrderId = OrderId;
        }

        public int Id { get; set; }
        public int? StoreId { get; set; }
        public int ProductId { get; set; }
        public int? Quantity { get; set; }
        public int OrderId { get; set; }
        
        public Product item { get; set; }
        public StoreFront Store { get; set; }

        public virtual Order Order { get; set; }
        /*public virtual Product Product { get; set; }*/
    }
}