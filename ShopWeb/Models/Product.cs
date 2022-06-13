using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWeb.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string ProductID { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Photopath { get; set; }
        public int StockQuantity { get; set; }
        public DateTime DatePosted { get; set; }
        public string CategoryID { get; set; }
    }
}
