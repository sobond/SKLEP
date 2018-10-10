using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sklep_MJ.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        public string FileIcon { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}