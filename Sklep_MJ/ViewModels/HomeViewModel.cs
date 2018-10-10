using Sklep_MJ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sklep_MJ.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Course> News { get; set; }
        public IEnumerable<Course> BestSellers { get; set; }
    }
}