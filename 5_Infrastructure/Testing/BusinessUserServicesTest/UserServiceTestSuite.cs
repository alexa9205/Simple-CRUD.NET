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

        // Success Test: Verifies that the correct user is returned when a valid ID is provided.
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


        // Null return test: Checks that null is returned when an ID that does not exist in the repository is provided.
        [Fact]
        public void GetById_ShouldReturnNull_WhenInvalidUserId()
        {
            // Arrange
            int invalidUserId = 999;
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(r => r.GetById(invalidUserId)).Returns((User)null);
            UserService userService = new UserService(userRepositoryMock.Object);

            // Act
            User result = userService.GetById(invalidUserId);

            // Assert
            Assert.Null(result);
        }

        //Repository call test: Verify that the GetById method of the repository is called with the correct ID.
        [Fact]
        public void GetById_ShouldCallRepositoryGetById_WhenValidUserId()
        {
            // Arrange
            int userId = 1;
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            UserService userService = new UserService(userRepositoryMock.Object);

            // Act
            User result = userService.GetById(userId);

            // Assert
            userRepositoryMock.Verify(r => r.GetById(userId), Times.Once);
        }



        // Verify that the Create method of the repository is called with the correct user.
        [Fact]
        public void CreateUser_ShouldCallRepositoryCreate_WithValidUser()
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


        // Test creation with null user: Verifies that no call is made to the repository if a null user is provided.
        [Fact]
        public void CreateUser_ShouldNotCallRepositoryCreate_WhenUserIsNull()
        {
            // Arrange
            User user = null;
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            UserService userService = new UserService(userRepositoryMock.Object);

            // Act
            userService.CreateUser(user);

            // Assert
            userRepositoryMock.Verify(r => r.Create(It.IsAny<User>()), Times.Never);
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
