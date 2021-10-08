using System;
using System.Collections.Generic;
using Serilog;

namespace Models
{
    public class Customer
    {
        public Customer() { }

        public Customer(int Id) : this()
        {
            this.Id = Id;
        }

        public Customer(string username) : this()
        {
            this.Username = username;
        }

        public Customer(string username, string password) : this(username)
        {
            this.Password = password;
        }

        public Customer(string username, string password, int age) : this(username, password)
        {
            this.Age = age;
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"ID: {this.Id} | USERNAME: {this.Username} | AGE: {this.Age}";
        }
    }
}
