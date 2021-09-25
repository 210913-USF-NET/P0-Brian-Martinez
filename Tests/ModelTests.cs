using System;
using Xunit;
using Models;

namespace Tests
{
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
        public void CustomerShouldCreate()
        {
            Customer test = new Customer();

            Assert.NotNull(test);
        }

        // [Theory]
        // [InlineData("")]
        // [InlineData("!@#$%^&*")]
        // public void CustomerShouldNotAllowInvalidData(string input)
        // {
        //     Customer test = new Customer();
            
        //     Assert.Throws<Exception>(() => test.LastName = input);
        // }
    }
}
