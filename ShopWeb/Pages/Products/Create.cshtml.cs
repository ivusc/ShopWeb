using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopWeb.Data;
using ShopWeb.Models;

namespace ShopWeb.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly ShopWeb.Data.ShopWebContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateModel(ShopWeb.Data.ShopWebContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }

        [BindProperty]
        public IFormFile Photo { get; set; }

        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;
            if (Photo != null)
            {
                //using webHostEnv to get direct access to wwwroot folder,
                //and then to Images folder
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                
                //use guid to get a unique filename
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                
                //complete filepath
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                
                //copies the file to the filepath using a filestream
                using (var fileStream = new FileStream(filePath,FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        private static string RandomString(int length)
        {
            Random random = new();
            const string pool = "abcdefghijklmnopqrstuvwxyz0123456789";
            var chars = Enumerable.Range(0, length)
                .Select(x => pool[random.Next(0, pool.Length)]);
            return new string(chars.ToArray());
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if(Photo == null)
            {
                Product.Photopath = null;
            }
            else
            {
                Product.Photopath = ProcessUploadedFile();
            }
            
            Product.ProductID = RandomString(5);
            Product.DatePosted = DateTime.Now;
            
            _context.Product.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index",new { Message = "Product Added Successfully!" });
        }
    }
}
