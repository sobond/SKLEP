using Postal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sklep_MJ.ViewModels
{
    public class OrderFinishedEmail : Email
    {
        public String To { get; set; }
        public String From { get; set; }
        public int OrderId { get; set; }
    }
}