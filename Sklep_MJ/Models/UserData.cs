using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sklep_MJ.Models
{
    public class UserData
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        [Phone]
        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}