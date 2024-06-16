using DemoEx.Models;

namespace TestDemoEx
{
    public class UnitTest1
    {

        [Fact]
        public void GetUsers_ShouldReturnUsers()
        {
            // Act
            var users = DataBase.GetUsers();

            // Assert
            Assert.NotEmpty(users);
        }

        [Fact]
        public void GetRoles_ShouldReturnRoles()
        {
            // Act
            var roles = DataBase.GetRoles();

            // Assert
            Assert.NotEmpty(roles);
        }

        [Fact]
        public void GetOffices_ShouldReturnOffices()
        {
            // Act
            var offices = DataBase.GetOffices();

            // Assert
            Assert.NotEmpty(offices);
        }

        [Fact]
        public void RegUser_ShouldInsertUser()
        {
            // Arrange
            var user = new User
            {
                Email = "newuser@example.com",
                Pssword = "newpassword",
                FirstName = "New",
                LastName = "User"
            };

            // Act
            DataBase.RegUser(user);

            // Assert
            var users = DataBase.GetUsers();
            Assert.Contains(users, u => u.Email == user.Email);
        }

        [Fact]
        public void AddUser_ShouldInsertUser()
        {
            // Arrange
            var user = new User
            {
                RoleID = 1,
                Email = "adduser@example.com",
                Pssword = "password",
                FirstName = "Add",
                LastName = "User",
                OfficeID = 1,
                BirthDate = DateTime.Now,
                Image = "",
                Active = "Active"
            };

            // Act
            DataBase.AddUser(user);

            // Assert
            var users = DataBase.GetUsers();
            Assert.Contains(users, u => u.Email == user.Email);
        }

        [Fact]
        public void UpdateUser_ShouldUpdateUserDetails()
        {
            // Arrange
            var user = new User
            {
                ID = 2,
                RoleID = 1,
                Email = "updateduser@example.com",
                Pssword = "newpassword",
                FirstName = "Updated",
                LastName = "User",
                OfficeID = 1,
                BirthDate = DateTime.Now,
                Image = "",
                Active = "Active"
            };

            // Act
            DataBase.UpdateUser(user);

            // Assert
            var users = DataBase.GetUsers();
            Assert.Contains(users, u => u.Email == user.Email && u.FirstName == user.FirstName);
        }

        [Fact]
        public void DeleteUser_ShouldRemoveUser()
        {
            // Arrange
            int userId = 1;

            // Act
            DataBase.DeleteUser(userId);

            // Assert
            var users = DataBase.GetUsers();
            Assert.DoesNotContain(users, u => u.ID == userId);
        }

        [Fact]
        public void ValidateUser_ShouldReturnRole()
        {
            // Arrange
            string email = "will.johnson@example.com";
            string password = "password";

            // Act
            var role = DataBase.ValidateUser(email, password);

            // Assert
            Assert.Equal("Пользователь", role);
        }


    }
}