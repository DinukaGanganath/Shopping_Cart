using Microsoft.AspNetCore.Identity;

namespace Shopping_Cart.Models
{
    public class AppUser : IdentityUser
    {
        public string Occupation { get; set; }

    }
}
