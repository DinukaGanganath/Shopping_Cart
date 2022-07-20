using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        // GET: /admin/pages/create
        public IActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(context.Categories.OrderBy(x => x.Sorting), "Id", "Name");
            return View();
        }
    }
}
