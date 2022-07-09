﻿using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopping_Cart.Infrastructure;
using Shopping_Cart.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_Cart.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PagesController : Controller
    {
        private readonly ShoppingCartContext context;

        public PagesController(ShoppingCartContext context)
        {
            this.context = context;
        }

        // GET: /admin/pages
        public async Task<IActionResult> Index()
        {
            IQueryable<Page> pages = from p in context.Pages orderby p.Sorting select p;
            List<Page> pagesList = await pages.ToListAsync();
            return View(pagesList);
        }

        // GET: /admin/pages/details/5
        public async Task<IActionResult> Details(int id)
        {
            Page page = await context.Pages.FirstOrDefaultAsync(x => x.Id == id);
            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }

        // GET: /admin/pages/create
        public IActionResult Create() => View();

        // POST: /admin/pages/create
        [HttpPost]
        public async Task<IActionResult> Create(Page page)
        {
            page.Slug = page.Title.ToLower().Replace(" ", "-");
            page.Sorting = 100;
            if (!ModelState.IsValid)
            {
                
                var slug = await context.Pages.FirstOrDefaultAsync(x => x.Slug == page.Slug);

                if (slug != null)
                {
                    ModelState.AddModelError("", "The page already exists.");
                    return View(page);

                }

                context.Add(page);
                await context.SaveChangesAsync();
                TempData["Success"] = "The page has been added!";

                return RedirectToAction("Index");
            }
            return View(page);
        }
    }
}
