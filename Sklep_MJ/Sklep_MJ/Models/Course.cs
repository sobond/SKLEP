using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sklep_MJ.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime DateAdd { get; set; }
        public string FileIcon { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool Bestseller { get; set; }
        public bool Hidden { get; set; }

        public virtual Category Category { get; set; }

    }
}