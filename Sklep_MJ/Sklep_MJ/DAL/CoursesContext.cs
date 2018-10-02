using Sklep_MJ.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sklep_MJ.DAL
{
    public class CoursesContext : DbContext
    {
        public CoursesContext() : base("CoursesContext")
        { }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; } 
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderPosition> GetOrderPositions { get; set; }
    }
}