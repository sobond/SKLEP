using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sklep_MJ.ViewModels
{
    public class CartRemoveVM
    {
        public decimal CartFullPrice { get; set; }
        public int RemovedCount { get; set; }
        public int RemovedId { get; set; }
        public int CartItemsCount { get; set; }
    }
}