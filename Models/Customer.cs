using System;

namespace Models
{
    public class Customer
    {
        public Customer() {}

        public Customer(string name)
        {
            this.Name = name;
        }

        public Customer(string name, int age) : this(name)
        {
            this.Age = age;
        }

        public Customer(string name, int age, string state) : this(name, age)
        {
            this.State = state;
        }

        // public Customer(string name, int age, string state, long phone) : this(name, age, state)
        // {
        //     this.Phone = phone;
        // }

        public string Name {get; set;}
        public int Age {get; set;}
        public string State {get; set;}
        // public long Phone {get; set;}

        public override string ToString()
        {
            return $"Name: {this.Name}, Age: {this.Age}, State: {this.State}";
            //Phone: {this.Phone}
        }
    }
}
