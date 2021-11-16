using System;

using System.Linq;

using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Pages.Product.Delete
{
    /// <summary>
    /// Tests ProductModels
    /// </summary>
    public class ProductModelTests
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

        #region ToString

        /// <summary>
        /// Tests that ToString() method should return the string representation of the dish
        /// </summary>
        [Test]
        public void ToString_Valid_Should_Return_Product_As_String()
        {

            // Arrange
            var expected = "{\"Id\":null,\"Category\":null,\"Restaurant\":null,\"Address\":null,\"City\":null,\"State\":null,\"img\":null,\"Url\":null,\"Title\":null,\"Cuisine\":null,\"Description\":null,\"Ratings\":null,\"Reviews\":[],\"Price\":0}";
            
            // Act
            var result = pageModel.ToString();

            // Assert
            Assert.AreEqual(expected, result);

        }
        #endregion ToString

        #region GetCurrentRating

        /// <summary>
        /// Tests that GetCurrentRatings() method should return the 0 by default
        /// </summary>
        [Test]
        public void GetCurrentRating_Should_Return_Zero_As_Default()
        {
            // Arrange
            var expected = 0;
            
            // Act
            var result = pageModel.GetCurrentRating();

            // Assert
            Assert.AreEqual(expected, result);

        }

        /// <summary>
        /// Tests that GetCurrentRatings() method should return the average rating if Ratings is not null
        /// </summary>
        [Test]
        public void GetCurrentRating_Not_Null_Should_Return_Average_Rating()
        {
            
            // Arrange
            pageModel.Ratings = new int[] { 1, 2, 3, 4, 5 };
            
            var expected = 3;
            
            // Act
            var result = pageModel.GetCurrentRating();

            // Assert
            Assert.AreEqual(expected, result);

        }

        #endregion GetCurrentRating

        #region HasSearchQuery
        /// <summary>
        /// Tests that HasSearchQuery that searches on not null category should return true
        /// </summary>
        [Test]
        public void HasSearchQuery_Should_Search_Category_Should_Return_True()
        {
            // Arrange

            // Act
            pageModel.Category = "bogus";
            var result = pageModel.HasSearchQuery("Bogus");

            // Assert
            Assert.AreEqual(true, result);
        }
        
        /// <summary>
        /// Tests that HasSearchQuery that searches on not null restaurant should return true
        /// </summary>
        [Test]
        public void HasSearchQuery_Should_Search_Restaurant_Should_Return_True()
        {
            // Arrange

            // Act
            pageModel.Restaurant = "bogus";
            var result = pageModel.HasSearchQuery("Bogus");

            // Assert
            Assert.AreEqual(true, result);
        }

        /// <summary>
        /// Tests that HasSearchQuery that searches on not null city should return true
        /// </summary>
        [Test]
        public void HasSearchQuery_Should_Search_City_Should_Return_True()
        {
            // Arrange

            // Act
            pageModel.City = "bogus";
            var result = pageModel.HasSearchQuery("Bogus");

            // Assert
            Assert.AreEqual(true, result);
        }

        /// <summary>
        /// Tests that HasSearchQuery that searches on not null cuisine should return true
        /// </summary>
        [Test]
        public void HasSearchQuery_Should_Search_Cuisine_Should_Return_True()
        {
            // Arrange

            // Act
            pageModel.Cuisine = "bogus";
            var result = pageModel.HasSearchQuery("Bogus");

            // Assert
            Assert.AreEqual(true, result);
        }

        /// <summary>
        /// Tests that HasSearchQuery that searches on not null cuisine should return true
        /// </summary>
        [Test]
        public void HasSearchQuery_Should_Search_Title_Should_Return_True()
        {
            // Arrange

            // Act
            pageModel.Title = "bogus";
            var result = pageModel.HasSearchQuery("Bogus");

            // Assert
            Assert.AreEqual(true, result);
        }

        /// <summary>
        /// Tests that HasSearchQuery that searches on not null description should return true
        /// </summary>
        [Test]
        public void HasSearchQuery_Should_Search_Description_Return_True()
        {
            // Arrange

            // Act
            pageModel.Description = "bogus";
            var result = pageModel.HasSearchQuery("Bogus");

            // Assert
            Assert.AreEqual(true, result);
        }

        /// <summary>
        /// Tests that HasSearchQuery did not find result
        /// </summary>
        [Test]
        public void HasSearchQuery_Search__Not_Found_Should_Return_False()
        {
            // Arrange

            // Act
            pageModel.Description = "bogus";
            var result = pageModel.HasSearchQuery("superbogus");

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Tests that HasSearchQuery that searches null category should return false
        /// </summary>
        [Test]
        public void HasSearchQuery_Search_On_Null_Category_Should_Return_False()
        {
            // Arrange

            // Act
            pageModel.Category = "bogus";
            var result = pageModel.HasSearchQuery("superbogus");

            // Assert
            Assert.AreEqual(false, result);
        }
        /// <summary>
        /// Tests that HasSearchQuery that searches null Restaurant should return false
        /// </summary>
        [Test]
        public void HasSearchQuery_Search_On_Null_Restaurant_Should_Return_False()
        {
            // Arrange

            // Act
            pageModel.Restaurant = "bogus";
            var result = pageModel.HasSearchQuery("superbogus");

            // Assert
            Assert.AreEqual(false, result);
        }
        /// <summary>
        /// Tests that HasSearchQuery that searches null city should return false
        /// </summary>
        [Test]
        public void HasSearchQuery_Search_On_Null_City_Should_Return_False()
        {
            // Arrange

            // Act
            pageModel.City = "bogus";
            var result = pageModel.HasSearchQuery("superbogus");

            // Assert
            Assert.AreEqual(false, result);
        }
        /// <summary>
        /// Tests that HasSearchQuery that searches null Cuisine should return false
        /// </summary>
        [Test]
        public void HasSearchQuery_Search_On_Null_Cuisine_Should_Return_False()
        {
            // Arrange

            // Act
            pageModel.Cuisine = "bogus";
            var result = pageModel.HasSearchQuery("superbogus");

            // Assert
            Assert.AreEqual(false, result);
        }
        /// <summary>
        /// Tests that HasSearchQuery that searches null Title should return false
        /// </summary>
        [Test]
        public void HasSearchQuery_Search_On_Null_Title_Should_Return_False()
        {
            // Arrange

            // Act
            pageModel.Title = "bogus";
            var result = pageModel.HasSearchQuery("superbogus");

            // Assert
            Assert.AreEqual(false, result);
        }
        #endregion HasSearchQuery
    }
}