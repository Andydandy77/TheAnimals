using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoCrafts.WebSite.Controllers;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Controllers
{
    /// <summary>
    /// Unit Test for ProductController
    /// </summary>
    class ProductsControllerTest
    {
        #region TestSetup
        //Testing OnGet
        public static ProductsController pageModel;
        /// <summary>
        /// Initializing page model with TestHelper
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new ProductsController(TestHelper.ProductService)
            {

            };
        }

        #endregion TestSetup

        #region Patch
        
        /// <summary>
        /// Tests if patch returns Ok
        /// </summary>
        [Test]
        public void Patch_Valid_Should_Return_OK()
        {
            //Arrange
            var data = new ProductsController.RatingRequest
            {
                ProductId = "8oz",
                Rating = 4
            };
            //Act
            var result = pageModel.Patch(data) as OkResult;

            //Assert
            Assert.AreEqual(new OkResult().ToString(), result.ToString());
        }
        #endregion Patch

        #region Get
        /// <summary>
        /// Tests that Get method returns a list of products
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Get_Products()
        {
            // Arrange

            // Act
            IEnumerable<ProductModel> products = pageModel.Get();

            // Assert
            Assert.AreNotEqual(null, products);
        }

        #endregion Get
    }
}
