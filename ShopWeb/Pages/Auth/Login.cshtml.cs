using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopWeb.Models;
using ShopWeb.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace ShopWeb.Pages.Auth
{
    public class LoginModel : PageModel
    {
        private readonly ShopWebContext _context;

        public LoginModel(ShopWebContext context)
        {
            _context = context;
        }

        [BindProperty, Required(ErrorMessage ="You must enter your email.")]
        public string Email { get; set; }

        [BindProperty, Required(ErrorMessage = "You must enter your Password."), DataType(DataType.Password)]
        public string Password { get; set; }

        [BindProperty]
        public bool RememberMe { get; set; }

        public UserDetails userDetails { get; set; }

        private async Task CreateIdentity(List<Claim> claims)
        {
            var identity = new ClaimsIdentity(claims, "MyCookieAuth");
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = RememberMe
            };

            await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal, authProperties);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            userDetails = (from r in _context.Details
                           where Email == r.Email && Password == r.Password
                           select r).FirstOrDefault();

            if (userDetails != null && userDetails.Role == "Customer")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,userDetails.Email),
                    new Claim("Customer","true")
                };
                await CreateIdentity(claims);
                return RedirectToPage("/Index");
            }
            else if (userDetails != null && userDetails.Role == "Seller")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,userDetails.Email),
                    new Claim("Seller","true"),
                    new Claim("Customer","true")
                };
                await CreateIdentity(claims);
                return RedirectToPage("/Index", new { Message = "Login Success" });
            }

            return Page();
        }

        public void OnGet()
        {
        }
    }
}
