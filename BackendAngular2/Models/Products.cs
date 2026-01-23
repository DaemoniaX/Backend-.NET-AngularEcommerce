using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendAngular2.Models
{
    public class Products
    {
        public int id { get; set; }
        public string title { get; set; }
        public decimal price { get; set; }
        public string image { get; set; }
        public int stock { get; set; }
    }
}