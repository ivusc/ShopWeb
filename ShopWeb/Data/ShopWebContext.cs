using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopWeb.Models;

namespace ShopWeb.Data
{
    public class ShopWebContext : DbContext
    {
        public ShopWebContext (DbContextOptions<ShopWebContext> options)
            : base(options)
        {
        }

        public DbSet<ShopWeb.Models.Product> Product { get; set; }

        public DbSet<ShopWeb.Models.Cart> Cart { get; set; }

        public DbSet<ShopWeb.Models.UserDetails> Details { get; set; }
    }
}
