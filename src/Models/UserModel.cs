using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// Represents a user object
    /// </summary>
    public class UserModel
    {
        // Unique user ID
        public string Id { get; set; }

        // Individual user's username
        public string Username { get; set; }

        // The user's password
        public string Password { get; set; }
    }
}
