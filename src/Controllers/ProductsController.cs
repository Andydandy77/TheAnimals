using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Controllers
{
    /// <summary>
    /// Controller for the list of Products in the JSON
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="productService"></param>
        public ProductsController(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // service to access json data
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Gets an iterator over all of the products
        /// </summary>
        /// <returns>IEnumerable for all the products</returns>
        [HttpGet]
        public IEnumerable<ProductModel> Get()
        {
            return ProductService.GetAllData();
        }

        /// <summary>
        /// This adds a rating to the product
        /// </summary>
        /// <param name="request"></param>
        /// <returns>ActionResult telling whether the product was added</returns>
        [HttpPatch]
        public ActionResult Patch([FromBody] RatingRequest request)
        {
            ProductService.AddRating(request.ProductId, request.Rating);
            
            return Ok();
        }

        /// <summary>
        /// This contains information about a Product's Rating
        /// </summary>
        public class RatingRequest
        {
            // Id for the Product
            public string ProductId { get; set; }
            // Rating for the Product
            public int Rating { get; set; }
        }
    }
}