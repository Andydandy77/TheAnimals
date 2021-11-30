using System;

using System.Linq;

using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Pages.Product.Delete
{
    /// <summary>
    /// Tests UserModels
    /// </summary>
    public class UserModelTests
    {
        #region TestSetup

        /// <summary>
        /// Initialize a ProductModel with the TestHelper
        /// </summary>
        public static ProductModel pageModel;

        [SetUp]
        public void TestInitialize()
        {
            pageModel = new ProductModel()
            {
            };
        }

        #endregion TestSetup 

        #region IDGetAndSet

        /// <summary>
        /// Tests that ID getter function returns the right ID
        /// </summary>
        [Test]
        public void GetId_Should_Return_Id()
        {
            // Arrange
            var id = "123";
            UserModel u = new UserModel();

            // Act
            u.Id = "123";

            // Assert
            Assert.AreEqual(id, u.Id);
        }
        #endregion GetId

        /// <summary>
        /// Tests that username getter function returns the right username
        /// </summary>
        #region UsernameGetAndSet
        [Test]
        public void GetUsername_Valid_Should_Set_Username()
        {
            // Arrange
            var username = "user";
            UserModel u = new UserModel();

            // Act
            u.Username = "user";

            // Assert
            Assert.AreEqual(username, u.Username);
        }
        #endregion UsernameGetAndSet

        /// <summary>
        /// Tests that password getter function returns the right password
        /// </summary>
        #region PasswordGetAndSet
        [Test]
        public void GetPassword_Valid_Should_Set_Password()
        {
            // Arrange
            var password = "password";
            UserModel u = new UserModel();

            // Act
            u.Password = "password";

            // Assert
            Assert.AreEqual(password, u.Password);
        }
        #endregion UsernameGetAndSet



    }
}