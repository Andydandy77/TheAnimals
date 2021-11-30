
using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ContosoCrafts.WebSite.Services;
using System.Linq;

namespace UnitTests.Services.Models.UserServiceTests
{
    /// <summary>
    /// Tests the Product Service file
    /// </summary>
    public class UserFileProdcutService
    {
        #region TestSetup

        /// <summary>
        /// Initializes Tests
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup

        #region CreateUser
        /// <summary>
        /// Tests that new users are added to database
        /// </summary>
        [Test]
        public void CreateUser_Valid_Should_Add_to_JsonUserFile()
        {
            // Arrange
            var username = "aaaaaaaaa";
            var password = "password";

            // Act
            TestHelper.UserService.CreateUser(username, password);
            var data = TestHelper.UserService.GetUser(username);
            // Assert
            Assert.AreEqual(data.Username, username);


        }

        #endregion CreateUser

        #region GetUser
        [Test]
        public void GetUser_Invalid_Should_Return_Null()
        {
            // Arrange
            var username = "asdfaafsdfa";

            // Act
            var data = TestHelper.UserService.GetUser(username);

            // Assert
            Assert.AreEqual(null, data);

        }
        #endregion GetUser

        #region ValidatePassword 
        [Test]
        public void ValidatePassword_Valid_Should_Return_True()
        {
            // Arrange
            var username = "aaaaaaaaa";
            var password = "password";

            // Act
            TestHelper.UserService.CreateUser(username, password);
            var data = TestHelper.UserService.ValidatePassword(username, password);

            // Assert
            Assert.AreEqual(true, data);
        }

        [Test]
        public void ValidatePassword_Invalid_Should_Return_False()
        {
            // Arrange
            var username = "aaaaaaaaa";
            var password = "password";

            // Act
            TestHelper.UserService.CreateUser(username, password);
            var data = TestHelper.UserService.ValidatePassword(username, "wrongPassword");

            // Assert
            Assert.AreEqual(false, data);
        }
        #endregion ValidatePassword
    }
}