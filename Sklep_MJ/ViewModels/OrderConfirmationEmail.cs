using Postal;
using Sklep_MJ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sklep_MJ.ViewModels
{
    public class OrderConfirmationEmail : Email
    {
        public String To { get; set; }
        public String From { get; set; }
        public decimal Price { get; set; }
        public int OrderId { get; set; }
        public List<OrderPosition> OrderPositions { get; set; }
    }
}