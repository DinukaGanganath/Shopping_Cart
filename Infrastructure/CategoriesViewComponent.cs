using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopping_Cart.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_Cart.Infrastructure
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly ShoppingCartContext context;

        public CategoriesViewComponent(ShoppingCartContext context)
        {
            this.context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await GetPagesAsync();
            return View(categories);
        }

        private Task<List<Category>> GetPagesAsync()
        {
            return context.Categories.OrderBy(x => x.Sorting).ToListAsync();
        }
    }
}
