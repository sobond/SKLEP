using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sklep_MJ.Models
{
    public class CartPosition
    {
        public Course Course { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
    }
}