using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sklep_MJ.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string SecondName { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [StringLength(100)]
        public string City { get; set; }

        [Required]
        [StringLength(6)]
        public string PostCode { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Comment { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal Price { get; set; }

        public List<OrderPosition> OrderPositions { get; set; }
    }


    public enum OrderStatus
    {
        New,
        Finished
    }
}