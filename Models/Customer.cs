using System;
using System.Collections.Generic;

namespace Models
{
    public class Customer
    {
        public Customer() {
            this.Orders = new List<Order>();
        }

        public Customer(string firstname) : this()
        {
            this.FirstName = firstname;
        }

        public Customer(string firstname, string lastname) : this(firstname)
        {
            this.LastName = lastname;
        }

        public Customer(string firstname, string lastname, int age) : this(firstname, lastname)
        {
            this.Age = age;
        }

        public Customer(string firstname, string lastname, int age, string email) : this(firstname, lastname, age)
        {
            this.Email = email;
        }

        // public Customer(string firstname, string lastname, int age, string state, long phone) : this(firstname, lastname, age, state)
        // {
        //     this.Phone = phone;
        // }

        public string FirstName {get; set;}
        public string LastName {get; set;}
        public int Age {get; set;}
        public string Email {get; set;}
        // public long Phone {get; set;}
        public List<Order> Orders {get; set;}
 
        public override string ToString()
        {
            return $"NAME: {this.LastName}, {this.FirstName} | AGE: {this.Age}, | EMAIL: {this.Email}";
            //Phone: {this.Phone}
        }

        public bool Equals(Customer customer)
        {
            return this.Email == customer.Email;
        }
    }
}
