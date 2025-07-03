// Models/ApplicationUser.cs
using Microsoft.AspNetCore.Identity;

namespace app_example.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; } // Optional: custom field
        public string Branch { get; set; } // 👈 This property ties the user to a branch

    }
}
