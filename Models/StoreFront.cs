using System.Collections.Generic;

namespace Models
{
    public class StoreFront
    {
        public StoreFront() {}

        public int Id {get; set;}
        public string Name {get; set;}

        public List<Inventory> Inventories {get; set;}

        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}