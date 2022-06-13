using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopWeb.Data;
using ShopWeb.Models;

namespace ShopWeb.Pages.ShopCart
{
    public class DeleteModel : PageModel
    {
        private readonly ShopWeb.Data.ShopWebContext _context;

        public DeleteModel(ShopWeb.Data.ShopWebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cart Cart { get; set; }
        
        public Product Product { get; set; }

        public string Message { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cart = await _context.Cart.FirstOrDefaultAsync(m => m.ID == id);
            Product = (from r in _context.Product
                       where r.ProductID == Cart.ProductID
                       select r).SingleOrDefault();

            if (Cart == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cart = await _context.Cart.FindAsync(id);
            Product = (from r in _context.Product
                       where r.ProductID == Cart.ProductID
                       select r).SingleOrDefault();
            
            Product.StockQuantity += Cart.QuantityBought;
            _context.SaveChanges();

            if (Cart != null)
            {
                _context.Cart.Remove(Cart);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index",new { Message = "Removed item from cart" });
        }
    }
}
