using Microsoft.AspNetCore.Identity;

namespace GroceryAPI.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string FullName { get; set; }

    }
}
