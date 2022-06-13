using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWeb.Models
{
    public class Categories
    {
        public bool Clothes { get; set; }
        public bool Electronics { get; set; }
        public bool Appliances { get; set; }
        public bool Food { get; set; }
        public bool Others { get; set; }
    }
    
    public enum Category
    {
        Appliances, Clothes, Electronics, Food, Others
    }
}