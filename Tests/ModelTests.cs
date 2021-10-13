using System;
using Xunit;
using Models;

namespace Tests
{
    // im sorry Juniper i'm not sure if im doing these right
    public class ModelTests
    {
        [Fact]
        public void CustomerShouldSetValidData()
        {
            Customer test = new Customer();
            string username = "test customer";

            test.Username = username;

            Assert.Equal(username, test.Username);
        }

        [Fact]
        public void CustomerShouldSetValidDataPassword()
        {
            Customer test = new Customer();
            string pass = "test customer";

            test.Password = pass;

            Assert.Equal(pass, test.Password);
        }

        [Fact]
        public void StoreShouldSetValidData()
        {
            StoreFront test = new StoreFront();
            string testName = "New Store";

            test.Name = testName;

            Assert.Equal(testName, test.Name);
        }

        [Fact]
        public void CustomerShouldCreate()
        {
            Customer test = new Customer();

            Assert.NotNull(test);
        }

        [Fact]
        public void StoreFrontShouldCreate()
        {
            StoreFront test = new StoreFront();
            Assert.NotNull(test);
        }

        [Fact]
        public void ProductShouldCreate()
        {
            Product test = new Product();
            Assert.NotNull(test);
        }

        [Fact]
        public void LineShouldCreate()
        {
            LineItem test = new LineItem();
            Assert.NotNull(test);
        }

        [Fact]
        public void OrderShouldBeMade()
        {
            Order test = new Order();
            Assert.NotNull(test);
        }

        [Fact]
        public void InvShouldCreate()
        {
            Inventory test = new Inventory();
            Assert.NotNull(test);
        }
    }
}
