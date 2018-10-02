using System.Collections;
using System.Collections.Generic;

namespace Sklep_MJ.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FileIcon { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}