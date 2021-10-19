using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
namespace ContosoCrafts.WebSite.Pages
{

    /// <summary>
    /// Model for the Index page
    /// Contains functionality to access all Products
    /// </summary>
    public class IndexModel : PageModel
    {
        // Ilogger for write to the console and debugging
        private readonly ILogger<IndexModel> _logger;

        /// <summary>
        /// Default Constructor, sets the ILogger and ProductService
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public IndexModel(ILogger<IndexModel> logger,
            JsonFileProductService productService)
        {
            _logger = logger;
            ProductService = productService;
        }


        // ProductService to access data about products
        public JsonFileProductService ProductService { get; }
        // An IEnumerable that allows us to iterate over the Products
        public IEnumerable<ProductModel> Products { get; private set; }

        /// <summary>
        /// When this page loads this sets Products to the Products returned by
        /// ProductService.GetAllData()
        /// </summary>
        public void OnGet()
        {
            Products = ProductService.GetAllData();
        }
    }
}