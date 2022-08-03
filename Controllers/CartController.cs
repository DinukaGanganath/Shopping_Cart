using Microsoft.AspNetCore.Mvc;
using Shopping_Cart.Infrastructure;
using Shopping_Cart.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_Cart.Controllers
{
    public class CartController : Controller
    {
        private readonly ShoppingCartContext context;

        public CartController(ShoppingCartContext context)
        {
            this.context = context;
        }

        //GET: /cart
        public IActionResult Index()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            CartViewModel cartVM = new CartViewModel
            {
                CartItems = cart,
                GrandTotal = cart.Sum(x => x.Price * x.Quantity)
            };
            return View(cartVM);
        }

        //GET: /cart/add/5
        public async Task<IActionResult> Add(int id)
        {
            Product product = await context.Products.FindAsync(id);
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartItem cartItem = cart.Where(x => x.ProductId == id).FirstOrDefault();

            if(cartItem == null)
            {
                cart.Add(new CartItem(product));
            }
            else
            {
                cartItem.Quantity += 1;
            }
            HttpContext.Session.SetJson("Cart", cart);
            return RedirectToAction("Index");
        }
    }
}
