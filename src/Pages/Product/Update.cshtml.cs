using System.Linq;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using System;

namespace ContosoCrafts.WebSite.Pages.Product
{
    /// <summary>
    /// Manage the Update of the data for a single record
    /// </summary>
    public class UpdateModel : PageModel
    {

        // Data middletier
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public UpdateModel(JsonFileProductService productService)
        {

            ProductService = productService;
        
        }

        // The data to show, bind to it for the post
        [BindProperty]
        public ProductModel Product { get; set; }

        /// <summary>
        /// REST Get request
        /// Loads the Data
        /// </summary>
        /// <param name="id"></param>
        public void OnGet(string id)
        {

            Product  = ProductService.GetAllData().FirstOrDefault(m => m.Id.Equals(id));
        
        }

        /// <summary>
        /// Post the model back to the page
        /// The model is in the class variable Product
        /// Call the data layer to Update that data
        /// Then return to the index page
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (ValidateInput()) {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
                ProductService.UpdateData(Product);
                return RedirectToPage("./Index");
            }

            return null;
        }

        public bool ValidateInput()
        {
           if (Product.Title.Length > 50)
            {
                return false;
            }

           if (Product.Description.Length > 200)
            {
                return false;
            }

           if (Product.Restaurant.Length > 25)
            {
                return false;
            }

           if (Product.City.Length > 25)
            {
                return false;
            }

           if (Product.State.Length > 2)
            {
                return false;
            }

           if (Product.Cuisine.Length > 25)
            {
                return false;
            }

           if (Product.Address.Length > 50)
            {
                return false;
            }

           if (!Uri.IsWellFormedUriString(Product.Url, UriKind.Absolute))
            {
                return false;
            }

           if (Product.Price <= 0)
            {
                return false;
            }

           if (Product.Price > 100)
            {
                return false;
            }

            return true;
        }
    }
}