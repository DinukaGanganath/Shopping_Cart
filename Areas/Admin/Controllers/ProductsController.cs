using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopping_Cart.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_Cart.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly ShoppingCartContext context;

        public ProductsController(ShoppingCartContext context)
        {
            this.context = context;
        }

        // GET: /admin/products
        public async Task<IActionResult> Index()
        {
            return View(await context.Products.OrderByDescending(x => x.Id).Include(x=>x.Category).ToListAsync());
        }
    }
}
