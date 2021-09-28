using System.Collections.Generic;

namespace Models
{
    public class StoreFront
    {
        public StoreFront() { }
        public StoreFront(string name)
        {
            this.Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public List<Inventory> Inventory { get; set; }

        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}