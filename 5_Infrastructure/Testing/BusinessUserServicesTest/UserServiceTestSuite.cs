using Xunit;
using Moq;
using Business.IServices;
using Domain;
using Domain.IRepositories;
using Business;

namespace BusinessUserServicesTest
{
    public class UserServiceTestSuite
    {
      
        [Fact]
        public void GetById_ShouldReturnUser_WhenValidUserId()
        {
            // Arrange
            int userId = 1;
            User expectedUser = new User { Id = userId, Name = "John" };
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(r => r.GetById(userId)).Returns(expectedUser);
            UserService userService = new UserService(userRepositoryMock.Object);

            // Act
            User result = userService.GetById(userId);

            // Assert
            Assert.Equal(expectedUser, result);
        }

        [Fact]
        public void CreateUser_ShouldCallRepositoryCreate_WhenValidUser()
        {
            // Arrange
            User user = new User { Id = 1, Name = "John" };
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            UserService userService = new UserService(userRepositoryMock.Object);

            // Act
            userService.CreateUser(user);

            // Assert
            userRepositoryMock.Verify(r => r.Create(user), Times.Once);
        }

        [Fact]
        public void UpdateUser_ShouldCallRepositoryUpdate_WhenValidUser()
        {
            // Arrange
            User user = new User { Id = 1, Name = "John" };
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            UserService userService = new UserService(userRepositoryMock.Object);

            // Act
            userService.UpdateUser(user);

            // Assert
            userRepositoryMock.Verify(r => r.Update(user), Times.Once);
        }

        [Fact]
        public void DeleteUser_ShouldCallRepositoryDelete_WhenValidUserId()
        {
            // Arrange
            int userId = 1;
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            UserService userService = new UserService(userRepositoryMock.Object);

            // Act
            userService.DeleteUser(userId);

            // Assert
            userRepositoryMock.Verify(r => r.Delete(userId), Times.Once);
        }
    }
}
