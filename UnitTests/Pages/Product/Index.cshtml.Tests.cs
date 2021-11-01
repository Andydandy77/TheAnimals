using System.Linq;

using Microsoft.AspNetCore.Mvc.RazorPages;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;

namespace UnitTests.Pages.Product.Index
{
    /// <summary>
    /// IndexTests provides unit tests for Index.cshtml.cs
    /// </summary>
    public class IndexTests
    {
        #region TestSetup
        public static PageContext pageContext;

        // This is our model that we test OnGet
        public static IndexModel pageModel;

        /// <summary>
        /// This initializes page model from TestHelper.ProductService
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new IndexModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        /// <summary>
        /// This tests that Index's OnGet returns the list of dishes
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, pageModel.Products.ToList().Any());
        }
        #endregion OnGet
    }
}