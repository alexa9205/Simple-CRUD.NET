using System;
using System.Linq;
using Xunit;
using Domain;

namespace Domain.Test
{
    public class UserTestSuite
    {

        [Fact]
        public void UserProperties_SetAndGetCorrectValues()
        {
            // Arrange
            var user = new User();

            // Act
            user.Id = 1;
            user.Name = "John";
            user.Surname = "Doe";
            user.Age = 30;

            // Assert
            Assert.Equal(1, user.Id);
            Assert.Equal("John", user.Name);
            Assert.Equal("Doe", user.Surname);
            Assert.Equal(30, user.Age);
        }
    }
}
