using System.Linq;
using Domain;
using Domain.IRepositories;
using InfrastructureData;
using InfrastructureData.DBModel;
using Xunit;

namespace UserRepository.Test
{
    public class UserRepositoryTestSuite
    //{
    //    [Fact]
    //    public void GetById_ValidId_ReturnsUser()
    //    {
    //        // Arrange
    //        int id = 1;
    //        using (var context = new PersonsEntities())
    //        {
    //            context.Persona.Add(new Persona { Id = id, Nombre = "John", Apellido = "Doe", Edad = 30 });
    //            context.SaveChanges();

    //            var repository = new InfrastructureData.UserRepository(context);

    //            // Act
    //            var user = repository.GetById(id);

    //            // Assert
    //            Assert.NotNull(user);
    //            Assert.Equal(id, user.Id);
    //            Assert.Equal("John", user.Name);
    //            Assert.Equal("Doe", user.Surname);
    //            Assert.Equal(30, user.Age);
    //        }
    //    }

    //    [Fact]
    //    public void GetById_InvalidId_ReturnsNull()
    //    {
    //        // Arrange
    //        int id = 1;
    //        using (var context = new PersonsEntities())
    //        {
    //            // No personas added to the database

    //            var repository = new InfrastructureData.UserRepository(context);

    //            // Act
    //            var user = repository.GetById(id);

    //            // Assert
    //            Assert.Null(user);
    //        }
    //    }

    //    [Fact]
    //    public void Create_ValidUser_CreatesUserInDatabase()
    //    {
    //        // Arrange
    //        using (var context = new PersonsEntities())
    //        {
    //            var repository = new InfrastructureData.UserRepository(context);
    //            var user = new Domain.User { Name = "Jane", Surname = "Doe", Age = 25 };

    //            // Act
    //            repository.Create(user);

    //            // Assert
    //            Assert.NotEqual(0, user.Id); // Id should be assigned after creation

    //            var createdUser = context.Persona.FirstOrDefault(p => p.Id == user.Id);
    //            Assert.NotNull(createdUser);
    //            Assert.Equal(user.Id, createdUser.Id);
    //            Assert.Equal(user.Name, createdUser.Nombre);
    //            Assert.Equal(user.Surname, createdUser.Apellido);
    //            Assert.Equal(user.Age, createdUser.Edad);
    //        }
    //    }

    //    [Fact]
    //    public void Update_ExistingUser_UpdatesUserInDatabase()
    //    {
    //        // Arrange
    //        int id = 1;
    //        using (var context = new PersonsEntities())
    //        {
    //            context.Persona.Add(new Persona { Id = id, Nombre = "John", Apellido = "Doe", Edad = 30 });
    //            context.SaveChanges();

    //            var repository = new InfrastructureData.UserRepository(context);
    //            var updatedUser = new User { Id = id, Name = "Jane", Surname = "Doe", Age = 25 };

    //            // Act
    //            repository.Update(updatedUser);

    //            // Assert
    //            var user = context.Persona.FirstOrDefault(p => p.Id == id);
    //            Assert.NotNull(user);
    //            Assert.Equal(updatedUser.Name, user.Nombre);
    //            Assert.Equal(updatedUser.Surname, user.Apellido);
    //            Assert.Equal(updatedUser.Age, user.Edad);
    //        }
    //    }

    //    [Fact]
    //    public void Delete_ExistingUser_RemovesUserFromDatabase()
    //    {
    //        // Arrange
    //        int id = 1;
    //        using (var context = new PersonsEntities())
    //        {
    //            context.Persona.Add(new Persona { Id = id, Nombre = "John", Apellido = "Doe", Edad = 30 });
    //            context.SaveChanges();

    //            var repository = new InfrastructureData.UserRepository(context);

    //            // Act
    //            repository.Delete(id);

    //            // Assert
    //            var user = context.Persona.FirstOrDefault(p => p.Id == id);
    //            Assert.Null(user);
    //        }
    //    }
   // }
}

