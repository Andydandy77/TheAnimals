
using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;

namespace UnitTests.Pages.Product.Read
{
    /// <summary>
    /// ReadTests provides unit tests for Read.cshtml.cs
    /// </summary>
    public class ReadTests
    {
        #region TestSetup

        // This is our model that we test OnGet
        public static ReadModel pageModel;

        /// <summary>
        /// This initializes page model from TestHelper.ProductService
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new ReadModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// This tests that the onGet method for the read page has the correct information
        /// for 8oz burger in this case
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet("8oz");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Our signature burger - arugula, balsamic onions, hills bacon, beechers flagship cheddar, truffle aioli", pageModel.Product.Description);
        }

        /// <summary>
        /// Tests if passed id returns a null object. Should redirect page.
        /// </summary>
        [Test]
        public void OnGet_Invalid_Null_Input_Should_Redirect_To_Index()
        {
            // Arrange

            // Act
            var p = pageModel.OnGet("23423423423412312");

            // Assert
            Assert.IsInstanceOf(typeof(Microsoft.AspNetCore.Mvc.RedirectToPageResult), p);
        }
        #endregion OnGet
    }
}