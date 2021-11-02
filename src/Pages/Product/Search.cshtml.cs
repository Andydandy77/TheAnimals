using System.Linq;

using Microsoft.AspNetCore.Mvc.RazorPages;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using System.Collections.Generic;

namespace ContosoCrafts.WebSite.Pages.Product
{
    /// <summary>
    /// Read page will show information about the Dish
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

        [Microsoft.AspNetCore.Mvc.BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public int[] ratings;

        public int currentRating;

        /// <summary>
        /// REST Get request
        /// </summary>
        public void OnGet()
        {
            Products = ProductService.GetAllData();
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                Products = Products.Where(s => s.hasSearchQuery(SearchTerm));
            }

        }

        public bool searched()
        {
            if (SearchTerm == null)
            {
                return false;
            }
            return true;
        }

    }
}
