
using Bunit;
using NUnit.Framework;

using ContosoCrafts.WebSite.Components;
using Microsoft.Extensions.DependencyInjection;
using ContosoCrafts.WebSite.Services;
using System.Linq;
using AngleSharp.Dom;

namespace UnitTests.Components
{
    /// <summary>
    /// Runs tests on on Product List razor component
    /// </summary>
    public class ProductListTests : BunitTestContext
    {
        #region TestSetup

        /// <summary>
        /// Sets up tests
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup

        /// <summary>
        /// Tests that product list should return content
        /// </summary>
        [Test]
        public void ProductList_Default_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            Services.AddSingleton<JsonFileUserService>(TestHelper.UserService);

            // Act
            var page = RenderComponent<ProductList>();

            // Get the Cards retrned
            var result = page.Markup;

            // Assert
            Assert.AreEqual(true, result.Contains("8oz"));
        }

        /// <summary>
        /// Tests that a valid id returns the correct content
        /// </summary>
        #region SelectProduct
        [Test]
        public void SelectProduct_Valid_ID_jenlooper_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            Services.AddSingleton<JsonFileUserService>(TestHelper.UserService);
            var id = "8oz";

            var page = RenderComponent<ProductList>();

            // Find the Buttons (more info)
            var buttonList = page.FindAll("Button");

            // Find the one that matches the ID looking for and click it
            var button = buttonList.First(m => m.OuterHtml.Contains(id));

            // Act
            button.Click();

            // Get the markup to use for the assert
            var pageMarkup = page.Markup;

            // Assert
            Assert.AreEqual(true, pageMarkup.Contains("Our signature burger - arugula, balsamic onions, hills bacon, beechers flagship cheddar, truffle aioli"));
        }
        #endregion SelectProduct

        #region SubmitRating

        /// <summary>
        /// Tests that a valid vote will change the star rating
        /// </summary>
        [Test]
        public void SubmitRating_Valid_ID_Click_Unstared_Should_Increment_Count_And_Check_Star()
        {
            /*
             This test tests that the SubmitRating will change the vote as well as the Star checked
             Because the star check is a calculation of the ratings, using a record that has no stars and checking one makes it clear what was changed

            The test needs to open the page
            Then open the popup on the card
            Then record the state of the count and star check status
            Then check a star
            Then check again the state of the cound and star check status

            */

            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            Services.AddSingleton<JsonFileUserService>(TestHelper.UserService);
            var id = "MoreInfoButton_6b1025ff-7e6d-4e0e-8001-c841365325b0";

            var page = RenderComponent<ProductList>();

            // Find the Buttons (more info)
            var buttonList = page.FindAll("Button");

            // Find the one that matches the ID looking for and click it
            var button = buttonList.First(m => m.OuterHtml.Contains(id));
            button.Click();

            // Get the markup of the page post the Click action
            var buttonMarkup = page.Markup;

            // Get the Star Buttons
            var starButtonList = page.FindAll("span");

            // Get the Vote Count
            // Get the Vote Count, the List should have 7 elements, element 2 is the string for the count
            var preVoteCountSpan = starButtonList[1];
            var preVoteCountString = preVoteCountSpan.OuterHtml;

            // Get the First star item from the list, it should not be checked
            var starButton = starButtonList.First(m=>!string.IsNullOrEmpty(m.ClassName) && m.ClassName.Contains("fa fa-star"));

            // Save the html for it to compare after the click
            var preStarChange = starButton.OuterHtml;

            // Act

            // Click the star button
            starButton.Click();

            // Get the markup to use for the assert
            buttonMarkup = page.Markup;

            // Get the Star Buttons
            starButtonList = page.FindAll("span");

            // Get the Vote Count, the List should have 7 elements, element 2 is the string for the count
            var postVoteCountSpan = starButtonList[1];
            var postVoteCountString = postVoteCountSpan.OuterHtml;

            // Get the Last stared item from the list
            starButton = starButtonList.First(m => !string.IsNullOrEmpty(m.ClassName) && m.ClassName.Contains("fa fa-star checked"));

            // Save the html for it to compare after the click
            var postStarChange = starButton.OuterHtml;

            // Assert

            // Confirm that the record had no votes to start, and 1 vote after
            Assert.AreEqual(true, preVoteCountString.Contains("Be the first to vote!"));
            Assert.AreEqual(true, postVoteCountString.Contains("1 Vote"));
            Assert.AreEqual(false, preVoteCountString.Equals(postVoteCountString));
        }

        /// <summary>
        /// Tests that submitting a rating will change the vote count
        /// </summary>
        [Test]
        public void SubmitRating_Valid_ID_Click_Stared_Should_Increment_Count_And_Leave_Star_Check_Remaining()
        {
            /*
             This test tests that the SubmitRating will change the vote as well as the Star checked
             Because the star check is a calculation of the ratings, using a record that has no stars and checking one makes it clear what was changed

            The test needs to open the page
            Then open the popup on the card
            Then record the state of the count and star check status
            Then check a star
            Then check again the state of the cound and star check status

            */

            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            Services.AddSingleton<JsonFileUserService>(TestHelper.UserService);
            var id = "MoreInfoButton_8oz";

            var page = RenderComponent<ProductList>();

            // Find the Buttons (more info)
            var buttonList = page.FindAll("Button");

            // Find the one that matches the ID looking for and click it
            var button = buttonList.First(m => m.OuterHtml.Contains(id));
            button.Click();

            // Get the markup of the page post the Click action
            var buttonMarkup = page.Markup;

            // Get the Star Buttons
            var starButtonList = page.FindAll("span");

            // Get the Vote Count
            // Get the Vote Count, the List should have 7 elements, element 2 is the string for the count
            var preVoteCountSpan = starButtonList[1];
            var preVoteCountString = preVoteCountSpan.OuterHtml;

            // Get the Last star item from the list, it should one that is checked
            var starButton = starButtonList.Last(m => !string.IsNullOrEmpty(m.ClassName) && m.ClassName.Contains("fa fa-star checked"));

            // Save the html for it to compare after the click
            var preStarChange = starButton.OuterHtml;

            // Act

            // Click the star button
            starButton.Click();

            // Get the markup to use for the assert
            buttonMarkup = page.Markup;

            // Get the Star Buttons
            starButtonList = page.FindAll("span");

            // Get the Vote Count, the List should have 7 elements, element 2 is the string for the count
            var postVoteCountSpan = starButtonList[1];
            var postVoteCountString = postVoteCountSpan.OuterHtml;

            // Get the Last stared item from the list
            starButton = starButtonList.Last(m => !string.IsNullOrEmpty(m.ClassName) && m.ClassName.Contains("fa fa-star checked"));

            // Save the html for it to compare after the click
            var postStarChange = starButton.OuterHtml;

            // Assert

            // Confirm that the record had no votes to start, and 1 vote after
            Assert.AreEqual(true, preVoteCountString.Contains("11 Votes"));
            Assert.AreEqual(true, postVoteCountString.Contains("12 Votes"));
            Assert.AreEqual(false, preVoteCountString.Equals(postVoteCountString));
        }
        #endregion SubmitRating

        #region GetTheBest
        /// <summary>
        /// Tests that clicking on the GetTheBest button will reorder the list to show the higest rated items on top
        /// </summary>
        [Test]
        public void GetTheBest_Valid_Click_Should_Display_Products_By_Rating_Descending()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            Services.AddSingleton<JsonFileUserService>(TestHelper.UserService);
            var id = "GetMeTheBest";

            var page = RenderComponent<ProductList>();

            // Find the Buttons and click on GetMeTheBest button
            var buttonList = page.FindAll("Button");
            var button = buttonList.First(m => m.OuterHtml.Contains(id));

            button.Click();

            // Get the markup of the page post the Click action
            var buttonMarkup = page.Markup;

            var newButtonList = page.FindAll("Button");
            button = newButtonList.First(m => m.OuterHtml.Contains("More Info"));

            button.Click();

            var starButtonList = page.FindAll("span");

            var voteCountSpan = starButtonList[1];
            var voteCountString = voteCountSpan.OuterHtml;

            Assert.AreEqual(true, voteCountString.Contains("4 Votes"));
        }
        #endregion

        #region CategoryFilter
        /// <summary>
        /// Filtering by category should only show items of that category
        /// </summary>
        [Test]
        public void FilterByCategory_Valid_Click_Should_Display_Products_Only_Of_Selected_Category()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            Services.AddSingleton<JsonFileUserService>(TestHelper.UserService);
            var id = "FilterByCategory_Burger";

            var page = RenderComponent<ProductList>();

            // Find the Buttons and click on GetMeTheBest button
            var buttonList = page.FindAll("Button");
            var button = buttonList.First(m => m.OuterHtml.Contains(id));

            button.Click();

            // Get the markup of the page post the Click action
            var buttonMarkup = page.Markup;

            var newButtonList = page.FindAll("Button");
            button = newButtonList.First(m => m.OuterHtml.Contains("More Info"));

            button.Click();

            var pageMarkup = page.Markup;

            // Assert
            Assert.AreEqual(true, pageMarkup.Contains("Burger"));
        }
        #endregion

        #region CuisineFilter
        /// <summary>
        /// Filtering by cuisine should only show items of that cuisine
        /// </summary>
        [Test]
        public void FilterByCuisine_Valid_Click_Should_Display_Products_Only_Of_Selected_Cuisine()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            Services.AddSingleton<JsonFileUserService>(TestHelper.UserService);
            var id = "FilterByCuisine_Italian";

            var page = RenderComponent<ProductList>();

            // Find the Buttons and click on GetMeTheBest button
            var buttonList = page.FindAll("Button");
            var button = buttonList.First(m => m.OuterHtml.Contains(id));

            button.Click();

            // Get the markup of the page post the Click action
            var buttonMarkup = page.Markup;

            var newButtonList = page.FindAll("Button");
            button = newButtonList.First(m => m.OuterHtml.Contains("More Info"));

            button.Click();

            var pageMarkup = page.Markup;

            // Assert
            Assert.AreEqual(true, pageMarkup.Contains("Italian"));
        }
        #endregion

        #region CityFilter
        /// <summary>
        /// Filtering by city should only show items of that city
        /// </summary>
        [Test]
        public void FilterByCity_Valid_Click_Should_Display_Products_Only_Of_Selected_City()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            Services.AddSingleton<JsonFileUserService>(TestHelper.UserService);
            var id = "FilterByCity_Seattle";

            var page = RenderComponent<ProductList>();

            // Find the Buttons and click on GetMeTheBest button
            var buttonList = page.FindAll("Button");
            var button = buttonList.First(m => m.OuterHtml.Contains(id));

            button.Click();

            // Get the markup of the page post the Click action
            var buttonMarkup = page.Markup;

            var newButtonList = page.FindAll("Button");
            button = newButtonList.First(m => m.OuterHtml.Contains("More Info"));

            button.Click();

            var pageMarkup = page.Markup;

            // Assert
            Assert.AreEqual(true, pageMarkup.Contains("Seattle"));
        }
        #endregion

        #region PriceFilter
        /// <summary>
        /// Filtering by price should only show items of that price
        /// </summary>
        [Test]
        public void FilterByPrice_Valid_Click_Should_Display_Products_Only_Of_Selected_Price()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            Services.AddSingleton<JsonFileUserService>(TestHelper.UserService);
            var id = "FilterByPrice_0-5";

            var page = RenderComponent<ProductList>();

            // Find the Buttons and click on GetMeTheBest button
            var buttonList = page.FindAll("Button");
            var button = buttonList.First(m => m.OuterHtml.Contains(id));

            button.Click();

            // Get the markup of the page post the Click action
            var buttonMarkup = page.Markup;

            var newButtonList = page.FindAll("Button");
            button = newButtonList.First(m => m.OuterHtml.Contains("More Info"));

            button.Click();

            var pageMarkup = page.Markup;

            // Assert
            Assert.AreEqual(true, pageMarkup.Contains("1.5"));
        }
        #endregion

        #region Reset
        /// <summary>
        /// Resetting the filter should show the list how it was originally displayed
        /// </summary>
        [Test]
        public void Reset_Should_Clear_Filters_And_Show_8oz_First()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            Services.AddSingleton<JsonFileUserService>(TestHelper.UserService);
            var id = "FilterByPrice_0-5";

            var page = RenderComponent<ProductList>();

            // Find the Buttons and click on GetMeTheBest button
            var buttonList = page.FindAll("Button");
            var button = buttonList.First(m => m.OuterHtml.Contains(id));

            button.Click();

            // Get the markup of the page post the Click action
            var buttonMarkup = page.Markup;

            var newButtonList = page.FindAll("Button");

            // Find the resetButton
            var resetButton = newButtonList.First(m => m.OuterHtml.Contains("resetButton"));

            resetButton.Click();

            newButtonList = page.FindAll("Button");


            button = newButtonList.First(m => m.OuterHtml.Contains("More Info"));

            button.Click();

            var pageMarkup = page.Markup;

            // Assert
            Assert.AreEqual(true, pageMarkup.Contains("8oz"));
        }
        #endregion

        #region Search
        /// <summary>
        /// Tests filtering books by search term
        /// </summary>
        [Test]
        public void GetSearch_Dishes_Should_Should_Return_Valid_dishes()

        {

            // Arrange

            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            Services.AddSingleton<JsonFileUserService>(TestHelper.UserService);


            // Act

            var page = RenderComponent<ProductList>();



            // Find filter button

            IElement filterButton = null;

            foreach (var element in page.FindAll("button"))

            {

                if (element.Id != null && element.Id.Equals("Search"))

                {

                    filterButton = element;

                }

            }



            // Find filter text input field

            IElement filterText = null;

            foreach (var element in page.FindAll("input"))

            {

                if (element.Id.Equals("searchdish"))

                {

                    filterText = element;

                }

                if (element.Id != null)

                {

                    filterText = element;
                    break;

                }

            }



            // Enter search term

            filterText.Change("Burger");



            // Click filter button

            filterButton.Click();



            //Get the Cards returned

            var result = page.Markup;



            // Assert

            Assert.AreEqual(true, result.Contains("The 8oz"));



        }

        #endregion Search

        #region Clear
        [Test]

        public void ClearSearch_Should_Return_All_Valid_Dishes()

        {

            // Arrange

            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            Services.AddSingleton<JsonFileUserService>(TestHelper.UserService);



            // Act

            var page = RenderComponent<ProductList>();



            // Find filter button

            IElement filterButton = null;

            foreach (var element in page.FindAll("button"))

            {

                if (element.Id != null && element.Id.Equals("Clear"))

                {

                    filterButton = element;

                }

            }



            // Find filter text input field

            IElement filterText = null;

            foreach (var element in page.FindAll("input"))

            {

                if (element.Id.Equals("searchdish"))

                {

                    filterText = element;

                }

                if (element.Id != null)

                {

                    filterText = element;

                }

            }



            // Find the clear button

            IElement clearFilterButton = null;

            foreach (var element in page.FindAll("button"))

            {

                if (element.Id != null && element.Id.Equals("Clear"))

                {

                    clearFilterButton = element;

                }

            }



            //Get the all the unfiltered cards

            var preResult = page.Markup;



            // Enter search term

            filterText.Change("Burger");



            // Click filter button

            filterButton.Click();



            // Click clear filter button

            clearFilterButton.Click();

            filterText.Change("");



            //Get the Cards returned

            var postResult = page.Markup;



            // Assert

            Assert.AreEqual(1, postResult.CompareTo(preResult));

        }
        #endregion

    }
}