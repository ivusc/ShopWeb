using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopWeb.Data;
using ShopWeb.Models;

namespace ShopWeb.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly ShopWeb.Data.ShopWebContext _context;

        public IndexModel(ShopWeb.Data.ShopWebContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Product.ToListAsync();
        }
    }
}
