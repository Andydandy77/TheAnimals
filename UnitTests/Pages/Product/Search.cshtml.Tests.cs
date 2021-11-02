using System.Diagnostics;

using Microsoft.Extensions.Logging;

using NUnit.Framework;

using Moq;

using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;
using System.Linq;

namespace UnitTests.Pages.Product.Search
{
    class SearchTests
    {
        #region TestSetup

        // This is our model that we test OnGet
        public static SearchModel searchModel;

        /// <summary>
        /// This initializes page model from TestHelper.ProductService
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            searchModel = new SearchModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        /// <summary>
        /// This tests that the onGet method for the search page has the correct information
        //// </summary>
        [Test]
        public void OnGet_Valid_Should_Get_Products_Matching_SearchTerm()
        {
            // Arrange

            // Act
            searchModel.SearchTerm = "Burger";
            searchModel.OnGet();
            

            // Assert
            Assert.AreEqual(true, searchModel.ModelState.IsValid);
            foreach (ProductModel p in searchModel.Products)
            {
                Assert.AreEqual(true, p.Category.Contains("Burger"));
            }
        }
        #endregion OnGet


        #region SearchAdded
        [Test]
        public void SearchAdded_Valid_Should_Return_True()
        {
            // Arrange

            // Act
            searchModel.SearchTerm = "burger";

            // Assert
            Assert.AreEqual(true, searchModel.Searched());
        }

        [Test]
        public void SearchAdded_Null_Should_Return_False()
        {
            // Arrange

            // Act

            // Assert
            Assert.AreEqual(false, searchModel.Searched());

        }

        #endregion SearchAdded
    }
}
