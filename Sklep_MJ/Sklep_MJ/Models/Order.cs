using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sklep_MJ.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal Price { get; set; }

        List<OrderPosition> OrderPositions { get;set }
    }


    public enum OrderStatus
    {
        New,
        Finished
    }
}