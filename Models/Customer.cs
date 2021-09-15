using System;

namespace Models
{
    public class Customer
    {
        public Customer() {}

        //Constructor overloading (this is an example of polymorphism)
        //The constructor behaves differently depending on what is passed in it
        public Customer(string name) 
        {
            this.Name = name;
        }

        //constructor chaninng is done if the user does not provide age
        public Customer(string name, int age) : this(name)
        {
            this.Age = age;
        }

        public Customer(string name, int age, string city) : this(name, age)
        {
            this.City = city;
        }

        public string Name {get; set;}
        public int Age {get; set;}
        public string City {get; set;}
    }
}
