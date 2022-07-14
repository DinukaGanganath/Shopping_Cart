using Microsoft.EntityFrameworkCore;
using Shopping_Cart.Models;

namespace Shopping_Cart.Infrastructure
{
    public class ShoppingCartContext : DbContext
    {
        public ShoppingCartContext(DbContextOptions<ShoppingCartContext> options)
            : base(options) 
        { 
        }

        public DbSet<Page> Pages { get; set; }
        public DbSet<Category> Categories{ get; set; }
    }
}
