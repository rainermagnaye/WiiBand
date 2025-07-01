// Models/ApplicationUser.cs
using Microsoft.AspNetCore.Identity;

namespace app_example.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; } // Optional: custom field
    }
}
