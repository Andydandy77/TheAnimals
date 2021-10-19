using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages

{
    //returns Cache-Control: no-store,no-cache
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorModel : PageModel
    {
        // Id for the Request
        public string RequestId { get; set; }

        //returns True if RequestID is not Null
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        private readonly ILogger<ErrorModel> _logger;

        //Represents a type used to perform logging. 
        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        //handles GET exceptions
        public void OnGet()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}   