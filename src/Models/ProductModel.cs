using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// Represents a dish object
    /// </summary>
    public class ProductModel
    {
        // Id of dish
        public string Id { get; set; }
        // Type of dish
        public string Category { get; set; }
        // Restaurant where dish is sold
        public string Restaurant { get; set; }
        // Street address of restaurant
        public string Address { get; set; }
        // City of restaurant
        public string City { get; set; }
        // State of restaurant
        public string State { get; set; }
        // Image of dish
        [JsonPropertyName("img")]
        public string Image { get; set; }
        // Url for website of restaurant
        public string Url { get; set; }
        // Name of the dish at restaurant
        public string Title { get; set; }
        // Cuisine that the dish belongs to 
        public string Cuisine { get; set; }
        // Description of dish
        public string Description { get; set; }
        // User ratings of dish
        public int[] Ratings { get; set; }
        // User reviews of dish
        public string[] Reviews { get; set; }
        // Price of dish
        public float Price { get; set; }

        /// <summary>
        /// Returns string representation of the dish
        /// </summary>
        /// <returns>String represetnation of dish</returns>
        public override string ToString() => JsonSerializer.Serialize<ProductModel>(this);

        /// <summary>
        /// Gets current average rating of dish
        /// </summary>
        /// <returns>Average rating of dish</returns>
        public int GetCurrentRating()
        {
            int rating = 0;
            
            // If there are ratings, add all ratings and divide them by nuber of votes
            if (Ratings != null)
            {
                int voteCount = Ratings.Length;
                rating = Ratings.Sum() / voteCount;
            }

            // Return average rating of dish
            return rating;

        }

        /// <summary>
        /// This checks if any of the Model's fields contain the
        /// search keyword
        /// </summary>
        /// <param name="search"></param>
        /// <returns>True if the Model contains the search keywork,
        /// false otherwise </returns>
        public bool HasSearchQuery(string search)
        {
            search = search.ToLower();
            if (Category != null)
            {
                if (Category.ToLower().Contains(search))
                {
                    return true;
                }
            }

            if (Restaurant != null)
            {
                if (Restaurant.ToLower().Contains(search))
                {
                    return true;
                }
            }

            if (City != null)
            {
                if (City.ToLower().Contains(search))
                {
                    return true;
                }
            }


            if (Cuisine != null)
            {
                if (Cuisine.ToLower().Contains(search))
                {
                    return true;
                }
            }

            if (Title != null)
            {
                if (Title.ToLower().Contains(search))
                {
                    return true;
                }
            }

            if (Description != null)
            {
                if (Description.ToLower().Contains(search))
                {
                    return true;
                }
            }


            return false;
        }

 
    }
}