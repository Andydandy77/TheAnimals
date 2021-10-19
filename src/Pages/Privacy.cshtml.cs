using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// Privacy page
    /// </summary>
    public class PrivacyModel : PageModel
    {
        // Ilogger for write to the console and debugging
        private readonly ILogger<PrivacyModel> _logger;

        /// <summary>
        /// Constructor
        /// Initializes logger
        /// </summary>
        /// <param name="logger"></param>
        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get method
        /// </summary>
        public void OnGet()
        {
        }
    }
}
