using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopWeb.Data;
using ShopWeb.Models;


namespace ShopWeb.Pages.ShopCart
{
    public class AddToCartModel : PageModel
    {
        private readonly ShopWebContext _context;

        public AddToCartModel(ShopWebContext context)
        {
            _context = context;
        }
        
        public Product Product { get; set; }
        [BindProperty]
        public Cart Cart { get; set; }

        public void OnGet(string Id)
        {
            Product = (from r in _context.Product
                      where r.ProductID == Id
                      select r).SingleOrDefault();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Product = (from r in _context.Product
                       where r.ProductID == Cart.ProductID
                       select r).SingleOrDefault();

            Cart.CustomerID = User.Identity.Name;
            Cart.DateTimeBought = DateTime.Now;
            Product.StockQuantity -= Cart.QuantityBought;

            _context.Cart.Add(Cart);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
