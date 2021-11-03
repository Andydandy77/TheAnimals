using System.Linq;

using Microsoft.AspNetCore.Mvc.RazorPages;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using System.Collections.Generic;

namespace ContosoCrafts.WebSite.Pages.Product
{
    /// <summary>
    /// Search Page allows users to query all dishes by keyword
    /// </summary>
    public class SearchModel : PageModel
    {
        // Data middletier
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public SearchModel(JsonFileProductService productService)
        {
            ProductService = productService;
            SearchTerm = null;
        }

        // The data to show
        public IEnumerable<ProductModel> Products { get; private set; }

        // User's search query in the search bar
        [Microsoft.AspNetCore.Mvc.BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        /// <summary>
        /// REST Get request to show dishes by query
        /// </summary>
        public void OnGet()
        {
            Products = ProductService.GetAllData();
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                Products = Products.Where(s => s.HasSearchQuery(SearchTerm));
            }

        }

        /// <summary>
        /// This determines if a user has searched something in the search bar
        /// </summary>
        /// <returns>True if user has searched, false, otherwise</returns>
        public bool Searched()
        {
            if (SearchTerm == null)
            {
                return false;
            }
            return true;
        }

    }
}
