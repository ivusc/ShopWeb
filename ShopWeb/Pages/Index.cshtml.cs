using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopWeb.Data;
using ShopWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace ShopWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ShopWebContext _context;

        public IndexModel(ILogger<IndexModel> logger, ShopWebContext context)
        {
            _logger = logger;
            _context = context;
        }
        
        [BindProperty]
        public string SearchString { get; set; }
        [BindProperty]
        public Categories Category { get; set; }
        
        public List<Product> TempProducts { get; set; } = new List<Product>();
        public List<Product> Products { get; set; } = new List<Product>();
        public string Message { get; set; }
        
        public async Task OnGetAsync(string Message)
        {
            this.Message = Message;
            Products = await (from r in _context.Product
                              where r.StockQuantity > 0
                              select r).ToListAsync();

        }
        
        private async Task<List<Product>> FindItems(string category)
        {
            var products = await (from r in _context.Product
                        where r.CategoryID == category
                        select r).ToListAsync();
            return products;
        }
        
        public async Task OnPostAsync()
        {
            if(SearchString != null)
            {
                Products = await (from r in _context.Product
                                  where r.Name == SearchString
                                  select r).ToListAsync();
            }
            else
            {
                if(Category.Appliances == true)
                {
                   TempProducts = await FindItems("Appliances");
                    foreach (var item in TempProducts)
                    {
                        Products.Add(item);
                    }
                }

                if (Category.Clothes == true)
                {
                    TempProducts = await FindItems("Clothes");
                    foreach (var item in TempProducts)
                    {
                        Products.Add(item);
                    }
                }
                
                if (Category.Electronics == true)
                {
                    TempProducts = await FindItems("Electronics");
                    foreach (var item in TempProducts)
                    {
                        Products.Add(item);
                    }
                }

                if (Category.Food == true)
                {
                    TempProducts = await FindItems("Food");
                    foreach (var item in TempProducts)
                    {
                        Products.Add(item);
                    }
                }

                if (Category.Others == true)
                {
                    TempProducts = await FindItems("Others");
                    foreach (var item in TempProducts)
                    {
                        Products.Add(item);
                    }
                }
            }
        }

    }
}
