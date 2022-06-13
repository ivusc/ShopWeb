using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopWeb.Data;
using ShopWeb.Models;

namespace ShopWeb.Pages.ShopCart
{

    public class IndexModel : PageModel
    {
        private readonly ShopWeb.Data.ShopWebContext _context;

        public IndexModel(ShopWeb.Data.ShopWebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IList<Cart> Cart { get;set; }

        public List<string> PhotoPath { get; set; } = new List<string>();
       
        [BindProperty]
        public string PaymentMethod { get; set; }

        public float TotalPrice { get; set; }
        public string Message { get; set; }


        public async Task OnGetAsync(string Message)
        {
            this.Message = Message;
            Cart = await (from r in _context.Cart
                    where r.CustomerID == User.Identity.Name && r.Paid == false
                    select r).ToListAsync();

            foreach (var item in Cart)
            {
                var productPrice = (from r in _context.Product
                                where r.ProductID == item.ProductID
                                select r.Price).SingleOrDefault();
                
                var photoPath = (from r in _context.Product
                                 where r.ProductID == item.ProductID
                                 select r.Photopath).SingleOrDefault();
                
                PhotoPath.Add(photoPath);
                TotalPrice += productPrice * item.QuantityBought;
            }
        }

        public async Task OnPostAsync()
        {
            Cart = await (from r in _context.Cart
                          where r.CustomerID == User.Identity.Name
                          select r).ToListAsync();
            foreach(var item in Cart)
            {
                _context.Cart.Remove(item);
            }
            await _context.SaveChangesAsync();
        }
    }
}
