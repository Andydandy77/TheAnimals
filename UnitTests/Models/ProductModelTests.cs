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
            var expected = "{\"Id\":null,\"Category\":null,\"Restaurant\":null,\"Address\":null,\"City\":null,\"State\":null,\"img\":null,\"Url\":null,\"Title\":null,\"Cuisine\":null,\"Description\":null,\"Ratings\":null,\"Reviews\":null,\"Price\":0}";
            // Act
            var result = pageModel.ToString();

            // Assert
            Assert.AreEqual(expected, result);

        }
        #endregion ToString

        #region GetCurrentRating
        /// <summary>
        /// Tests that GetCurrentRating() method should return 0 as default rating
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
        #endregion GetCurrentRating

    }
}
