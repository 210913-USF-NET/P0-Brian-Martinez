using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class StoreFront
    {
        public StoreFront()
        {
            Inventories = new HashSet<Inventory>();
            LineItems = new HashSet<LineItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<LineItem> LineItems { get; set; }
    }
}
