
using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Pages.Product.Update
{
    /// <summary>
    /// Unit test for Update.cshtml.cs
    /// </summary>
    public class UpdateTests
    {
        #region TestSetup
        //Testing OnGet
        public static UpdateModel pageModel;

        /// <summary>
        /// Initializing page model with TestHelper
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new UpdateModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// Tests if OnGet returns a Valid set of products
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet("8oz");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("The 8oz", pageModel.Product.Title);
        }
        #endregion OnGet

        #region OnPost

        /// <summary>
        /// Tests if OnPost returns a valid set of products
        /// </summary>
        [Test]
        public void OnPost_Valid_Should_Return_Products()
        {
            // Arrange
            pageModel.Product = new ProductModel
            {
                Id = "sandwich",
                Category = "category",
                Restaurant = "restaurant",
                Price = 10,
                City = "city",
                State = "WA",
                Title = "title",
                Description = "description",
                Url = "https://www.google.com",
                Image = "https://pbs.twimg.com/profile_images/1022058466708516864/xvWejEyc.jpg",
                UberEats = "ubereats",
                Cuisine = "mexican",
                Address = "189 north ave"
            };

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Index"));
        }
        ///<summary>
        /// Tests if OnPost is Returning an Invalid when the product is not available
        ///</summary>
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

        #region ValidateInput

        [Test]
        public void Invalid_Title_Length_Does_Not_Return_Index()
        {
            // Arrange
            pageModel.Product = new ProductModel
            {
                Id = "sandwich",
                Category = "category",
                Restaurant = "restaurant",
                Price = 10,
                City = "city",
                State = "WA",
                Title = "titletitletitletitletitletitletitletitletitletitletitletitletitletitletitletitletitletitletitletitletitletitle",
                Description = "description",
                Url = "https://www.google.com",
                Image = "https://pbs.twimg.com/profile_images/1022058466708516864/xvWejEyc.jpg",
                UberEats = "ubereats",
                Cuisine = "mexican",
                Address = "189 north ave"
            };

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(null, result);
        }

        [Test]
        public void Invalid_Description_Length_Does_Not_Return_Index()
        {
            // Arrange
            pageModel.Product = new ProductModel
            {
                Id = "sandwich",
                Category = "category",
                Restaurant = "restaurant",
                Price = 10,
                City = "city",
                State = "WA",
                Title = "title",
                Description = "descriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescription",
                Url = "https://www.google.com",
                Image = "https://pbs.twimg.com/profile_images/1022058466708516864/xvWejEyc.jpg",
                UberEats = "ubereats",
                Cuisine = "mexican",
                Address = "189 north ave"
            };

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(null, result);
        }

        [Test]
        public void Invalid_Restaurant_Length_Does_Not_Return_Index()
        {
            // Arrange
            pageModel.Product = new ProductModel
            {
                Id = "sandwich",
                Category = "category",
                Restaurant = "restaurantrestaurantrestaurantrestaurant",
                Price = 10,
                City = "city",
                State = "WA",
                Title = "title",
                Description = "description",
                Url = "https://www.google.com",
                Image = "https://pbs.twimg.com/profile_images/1022058466708516864/xvWejEyc.jpg",
                UberEats = "ubereats",
                Cuisine = "mexican",
                Address = "189 north ave"
            };

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(null, result);
        }

        [Test]
        public void Invalid_City_Length_Does_Not_Return_Index()
        {
            // Arrange
            pageModel.Product = new ProductModel
            {
                Id = "sandwich",
                Category = "category",
                Restaurant = "restaurant",
                Price = 10,
                City = "citycitycitycitycitycitycitycitycitycitycitycitycitycitycitycity",
                State = "WA",
                Title = "title",
                Description = "description",
                Url = "https://www.google.com",
                Image = "https://pbs.twimg.com/profile_images/1022058466708516864/xvWejEyc.jpg",
                UberEats = "ubereats",
                Cuisine = "mexican",
                Address = "189 north ave"
            };

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(null, result);
        }

        [Test]
        public void Invalid_State_Length_Does_Not_Return_Index()
        {
            // Arrange
            pageModel.Product = new ProductModel
            {
                Id = "sandwich",
                Category = "category",
                Restaurant = "restaurant",
                Price = 10,
                City = "city",
                State = "WAA",
                Title = "title",
                Description = "description",
                Url = "https://www.google.com",
                Image = "https://pbs.twimg.com/profile_images/1022058466708516864/xvWejEyc.jpg",
                UberEats = "ubereats",
                Cuisine = "mexican",
                Address = "189 north ave"
            };

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(null, result);
        }

        [Test]
        public void Invalid_Cuisine_Length_Does_Not_Return_Index()
        {
            // Arrange
            pageModel.Product = new ProductModel
            {
                Id = "sandwich",
                Category = "category",
                Restaurant = "restaurant",
                Price = 10,
                City = "city",
                State = "WA",
                Title = "title",
                Description = "description",
                Url = "https://www.google.com",
                Image = "https://pbs.twimg.com/profile_images/1022058466708516864/xvWejEyc.jpg",
                UberEats = "ubereats",
                Cuisine = "mexicanmexicanmexicanmexicanmexicanmexicanmexicanmexican",
                Address = "189 north ave"
            };

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(null, result);
        }

        [Test]
        public void Invalid_Address_Length_Does_Not_Return_Index()
        {
            // Arrange
            pageModel.Product = new ProductModel
            {
                Id = "sandwich",
                Category = "category",
                Restaurant = "restaurant",
                Price = 10,
                City = "city",
                State = "WA",
                Title = "title",
                Description = "description",
                Url = "https://www.google.com",
                Image = "https://pbs.twimg.com/profile_images/1022058466708516864/xvWejEyc.jpg",
                UberEats = "ubereats",
                Cuisine = "mexican",
                Address = "189 north ave189 north ave189 north ave189 north ave189 north ave189 north ave189 north ave189 north ave"
            };

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(null, result);
        }

        [Test]
        public void Invalid_URL_Does_Not_Return_Index()
        {
            // Arrange
            pageModel.Product = new ProductModel
            {
                Id = "sandwich",
                Category = "category",
                Restaurant = "restaurant",
                Price = 10,
                City = "city",
                State = "WA",
                Title = "title",
                Description = "description",
                Url = "https:/ww.google.com",
                Image = "https://pbs.twimg.com/profile_images/1022058466708516864/xvWejEyc.jpg",
                UberEats = "ubereats",
                Cuisine = "mexican",
                Address = "189 north"
            };

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(null, result);
        }

        [Test]
        public void Invalid_Low_Price_Does_Not_Return_Index()
        {
            // Arrange
            pageModel.Product = new ProductModel
            {
                Id = "sandwich",
                Category = "category",
                Restaurant = "restaurant",
                Price = -1,
                City = "city",
                State = "WA",
                Title = "title",
                Description = "description",
                Url = "https://www.google.com",
                Image = "https://pbs.twimg.com/profile_images/1022058466708516864/xvWejEyc.jpg",
                UberEats = "ubereats",
                Cuisine = "mexican",
                Address = "189 north"
            };

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(null, result);
        }

        [Test]
        public void Invalid_High_Price_Does_Not_Return_Index()
        {
            // Arrange
            pageModel.Product = new ProductModel
            {
                Id = "sandwich",
                Category = "category",
                Restaurant = "restaurant",
                Price = 1000,
                City = "city",
                State = "WA",
                Title = "title",
                Description = "description",
                Url = "https://www.google.com",
                Image = "https://pbs.twimg.com/profile_images/1022058466708516864/xvWejEyc.jpg",
                UberEats = "ubereats",
                Cuisine = "mexican",
                Address = "189 north"
            };

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(null, result);
        }

        #endregion ValidateInput
    }
}