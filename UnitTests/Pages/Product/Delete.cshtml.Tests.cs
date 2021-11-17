using System.Linq;

using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Pages.Product.Delete
{
    /// <summary>
    /// Tests Delete page
    /// </summary>
    public class DeleteTests
    {
        #region TestSetup

        /// <summary>
        /// Initialize a DeleteModel with the TestHelper
        /// </summary>
        public static DeleteModel pageModel;

        [SetUp]
        public void TestInitialize()
        {
            pageModel = new DeleteModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup 

        #region OnGet

        /// <summary>
        /// Tests that OnGet method should return the items in the database
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet("8oz");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Burger", pageModel.Product.Category);
        }

        /// <summary>
        /// Tests that OnGet method redirects to different page when input is invalid
        /// </summary>
        [Test]
        public void OnGet_Invalid_Null_Input_Should_Redirect_To_Invalid_Product()
        {
            // Arrange

            // Act
            var p = pageModel.OnGet("23423412312");

            // Assert
            Assert.IsInstanceOf(typeof(Microsoft.AspNetCore.Mvc.RedirectToPageResult), p);
        }

        #endregion OnGet

        #region OnPost

        /// <summary>
        /// Tests that OnPost method is returning a valid record and record is actually deleted
        /// </summary>
        [Test]
        public void OnPost_Valid_Should_Return_Products()
        {
            // Arrange

            // First Create the product to delete
            pageModel.Product = TestHelper.ProductService.CreateData();
            pageModel.Product.Title = "Example to Delete";
            TestHelper.ProductService.UpdateData(pageModel.Product);

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Index"));

            // Confirm the item is deleted
            Assert.AreEqual(null, TestHelper.ProductService.GetAllData().FirstOrDefault(m => m.Id.Equals(pageModel.Product.Id)));
        }

        /// <summary>
        /// Tests that OnPost method is returning an invalid record and record is not actually deleted
        /// </summary>
        [Test]
        public void OnPost_InValid_Model_NotValid_Return_Page()
        {
            // Arrange

            // Force an invalid error state
            pageModel.ModelState.AddModelError("bogus", "bogus error");

            // Act
            var result = pageModel.OnPost() as ActionResult;

            // Assert
            Assert.AreEqual(false, pageModel.ModelState.IsValid);
        }

        #endregion OnPost
    }
}