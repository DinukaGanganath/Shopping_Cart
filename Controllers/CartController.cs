using Microsoft.AspNetCore.Mvc;
using Shopping_Cart.Infrastructure;
using Shopping_Cart.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shopping_Cart.Controllers
{
    public class CartController : Controller
    {
        private readonly ShoppingCartContext context;

        public CartController(ShoppingCartContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            CartViewModel cartVm = new CartViewModel
            {
                CartItems = cart,
                GrandTotal = cart.Sum(x => x.Price * x.Quantity)
            };
            return View();
        }
    }
}
