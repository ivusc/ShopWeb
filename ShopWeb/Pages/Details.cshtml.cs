using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopWeb.Data;
using ShopWeb.Models;

namespace ShopWeb.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly ShopWebContext _context;

        public DetailsModel(ShopWebContext context)
        {
            _context = context;
        }

        public Product Product { get; set; }

        public void OnGet(string Id)
        {
            Product = (from r in _context.Product
                       where r.ProductID == Id
                       select r).SingleOrDefault();
        }
    }
}
