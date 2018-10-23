using Sklep_MJ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sklep_MJ.ViewModels
{
    public class CartViewModel
    {
        public List<OrderPosition> OrderPositions { get; set; }
        public decimal TotalPrice { get; set; }
    }
}