using Sklep_MJ.Migrations;
using Sklep_MJ.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Sklep_MJ.DAL
{

    public class CoursesInitializer : MigrateDatabaseToLatestVersion<CoursesContext, Configuration>
    {


        public static void SeedCoursesData(CoursesContext context)
        {
            var categories = new List<Category>
            {
                new Category(){CategoryId=1, Name="asp", FileIcon="asp.png", Description="opis asp"},
                new Category(){CategoryId=2, Name="java", FileIcon="java.png", Description="opis java"},
                new Category(){CategoryId=3, Name="php", FileIcon="php.png", Description="opis php"},
                new Category(){CategoryId=4, Name="html", FileIcon="html.png", Description="opis html"},
                new Category(){CategoryId=5, Name="css", FileIcon="css.png", Description="opis css"},
                new Category(){CategoryId=6, Name="xml", FileIcon="xml.png", Description="opis xml"},
                new Category(){CategoryId=7, Name="c#", FileIcon="c#.png", Description="opis c#"}
                
            };
            categories.ForEach(c => context.Categories.AddOrUpdate(c));
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course(){Author = "jacek", Title="asp.net mvc", CategoryId = 1, Price = 99, Bestseller = true, FileIcon = "jacek.png", DateAdd = DateTime.Now, Description = "kurs jacka"},
                new Course(){Author = "tomek", Title="asp.net mvc3", CategoryId = 1, Price = 120, Bestseller = true, FileIcon = "tomek.png", DateAdd = DateTime.Now, Description = "kurs tomka"},
                new Course(){Author = "irek", Title="asp.net mvc4", CategoryId = 1, Price = 120, Bestseller = true, FileIcon = "irek.png", DateAdd = DateTime.Now, Description = "kurs irka"},
                new Course(){Author = "romek", Title="asp.net mvc5", CategoryId = 1, Price = 140, Bestseller = true, FileIcon = "romek.png", DateAdd = DateTime.Now, Description = "kurs romka"},

            };
            courses.ForEach(c => context.Courses.AddOrUpdate(c));
            context.SaveChanges();
        }
    }
}