using System;
using System.Collections.Generic;
using Serilog;

namespace Models
{
    public class Customer
    {
        public Customer() { }

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

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"ID: {this.Id} | NAME: {this.LastName}, {this.FirstName} | AGE: {this.Age}";
        }
    }
}
