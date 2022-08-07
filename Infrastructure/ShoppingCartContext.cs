using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Shopping_Cart.Models;

namespace Shopping_Cart.Infrastructure
{
    public class ShoppingCartContext : IdentityDbContext<AppUser>
    {
        public ShoppingCartContext(DbContextOptions<ShoppingCartContext> options)
            : base(options) 
        { 
        }

        public DbSet<Page> Pages { get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
