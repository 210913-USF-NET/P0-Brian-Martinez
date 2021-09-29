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
            string testLastName = "test customer";

            test.LastName = testLastName;

            Assert.Equal(testLastName, test.LastName);
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
    }
}
