using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopWeb.Data;
using ShopWeb.Models;

namespace ShopWeb.Pages.Auth
{
    [Authorize(Policy = "Seller")]
    public class AdminSignupModel : PageModel
    {
        private readonly ShopWebContext _context;

        public AdminSignupModel(ShopWebContext context)
        {
            _context = context;
        }

        [BindProperty, Required]
        public UserDetails newUser { get; set; }

        [BindProperty, Required]
        [DataType(DataType.Password)]
        public string Password1 { get; set; }

        [BindProperty, Required]
        [DataType(DataType.Password)]
        public string Password2 { get; set; }

        public string Message { get; set; }

        private void GetClaimsandIdentityAsync(UserDetails newUser)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,newUser.Email),
                new Claim("Seller","true"),
                new Claim("Customer","true")
            };
            var identity = new ClaimsIdentity(claims, "MyCookieAuth");
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

            //await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);
        }

        private bool EmailUsed()
        {
            var name = (from r in _context.Details
                        where r.Email == newUser.Email
                        select r).SingleOrDefault();
            if (name == null)
                return false;
            else return true;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();
            else if (Password1 != Password2)
            {
                Message = "Password entered are not the same.";
                return Page();
            }
            else
            {
                if (EmailUsed() == true)
                {
                    Message = "Email has been used.";
                    return Page();
                }
                if (Password1.Length < 4 || newUser.Email.Length < 5)
                {
                    Message = "Email or Password is too short.";
                    return Page();
                }
                newUser.Role = "Seller";
                newUser.Password = Password1;
                _context.Add(newUser);
                await _context.SaveChangesAsync();
                GetClaimsandIdentityAsync(newUser);
                Message = "Admin Account Created!";
                return Page();
            }
        }
    }
}
