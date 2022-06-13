using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWeb.Models
{
    public class Cart
    {
        public int ID { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string CustomerID { get; set; }
        public int QuantityBought { get; set; }
        public bool Paid { get; set; }
        public DateTime DateTimeBought { get; set; }
    }
}
