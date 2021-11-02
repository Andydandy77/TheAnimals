
using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;
using System.Linq;

namespace UnitTests.Pages.Product.AddRating
{
    public class JsonFileProductServiceTests
    {
        #region TestSetup

        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup

        #region AddRating
        [Test]
        public void AddRating_InValid_Product_Null_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ProductService.AddRating(null, 1);

            // Assert
            Assert.AreEqual(false, result);
        }
        // ....

        [Test]
        public void AddRating_Valid_Product_Valid_Rating_Valid_Should_Return_True()
        {
            // Arrange

            // Get the First data item
            var data = TestHelper.ProductService.GetAllData().First();
            var countOriginal = data.Ratings.Length;

            // Act
            var result = TestHelper.ProductService.AddRating(data.Id, 5);
            var dataNewList = TestHelper.ProductService.GetAllData().First();

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(countOriginal + 1, dataNewList.Ratings.Length);
            Assert.AreEqual(5, dataNewList.Ratings.Last());
        }

        [Test]
        public void AddRating_Valid_Product_Invalid_Rating_Greater_Than_Five_Should_Return_False()
        {
            // Arrange

            // Act
            var data = TestHelper.ProductService.GetAllData().First();
            var result = TestHelper.ProductService.AddRating(data.Id, 6);

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void AddRating_Valid_Product_Invalid_Rating_Less_Than_Zero_Should_Return_False()
        {
            // Arrange
            var data = TestHelper.ProductService.GetAllData().First();

            // Act
            var result = TestHelper.ProductService.AddRating(data.Id, -1);

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void AddRating_Invalid_Product_Doesnt_Exist_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ProductService.AddRating("Non-existant Product", 1);

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void AddRating_Valid_Product_No_Ratings_Should_Create_New_Array()
        {
            // Arrange
            ProductModel data = null;
            var dataId = TestHelper.ProductService.GetAllData().FirstOrDefault(m => m.Ratings == null).Id;

            // Act
            var result = TestHelper.ProductService.AddRating(dataId, 3);
            data = TestHelper.ProductService.GetAllData().FirstOrDefault(m => m.Id.Equals(dataId));

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(1, data.Ratings.Length);

        }
        #endregion AddRating

        #region UpdateData
        [Test]
        public void UpdateData_Invalid_Id_Should_Return_Null()
        {
            // Arrange

            // Act
            var data = TestHelper.ProductService.GetAllData().First();
            data.Id = null;
            var result = TestHelper.ProductService.UpdateData(data);

            // Assert
            Assert.AreEqual(null, result);

        }
        #endregion
    }
}