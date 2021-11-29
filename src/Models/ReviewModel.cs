namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// Reviews entered by the user about the Dish
    /// </summary>
    public class ReviewModel
    {
        // The ID for this comment, use a Guid so it is always unique
        public string Id { get; set; } = System.Guid.NewGuid().ToString();

        // The Comment
        public string Review { get; set; }

        // The Username of the user that wrote the review
        public string User { get; set; }
    }
}
