using Microsoft.AspNetCore.Mvc;
using Shopping_Cart.Infrastructure;

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

        public IActionResult Index()
        {
            return View();
        }
    }
}
