using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
                new Category(){CategoryId=1, Name="ASP", FileIcon="asp.png", Description="Kursy asp"},
                new Category(){CategoryId=2, Name="JAVA", FileIcon="java.png", Description="Kursy java"},
                new Category(){CategoryId=3, Name="PHP", FileIcon="php.png", Description="Kursy php"},
                new Category(){CategoryId=4, Name="HTML", FileIcon="html.png", Description="Kursy html"},
                new Category(){CategoryId=5, Name="CSS", FileIcon="css.png", Description="Kursy css"},
                new Category(){CategoryId=6, Name="XML", FileIcon="xml.png", Description="Kursy xml"},
                new Category(){CategoryId=7, Name="C#", FileIcon="c.png", Description="Kursy c#"}

            };
            categories.ForEach(c => context.Categories.AddOrUpdate(c));
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course(){CourseId=1, Author = "Michał Junior", Title="Kurs ASP JR", CategoryId = 1, Price = 40, Bestseller = false, FileIcon = "asp1.png", DateAdd = DateTime.Now, ShortDescription="ASP1", Description = "Kurs dla Jurniora przygotowany przez Michała"},
                new Course(){CourseId=2, Author = "Adam Regular", Title="Kurs ASP MID", CategoryId = 1, Price = 270, Bestseller = true, FileIcon = "asp2.png", DateAdd = DateTime.Now, ShortDescription="ASP2", Description = "Kurs dla Regulara przygotowany przez Adama"},
                new Course(){CourseId=3, Author = "Maciej Senior", Title="Kurs ASP SR", CategoryId = 1, Price = 510, Bestseller = false, FileIcon = "asp3.png", DateAdd = DateTime.Now, ShortDescription="ASP3", Description = " Kurs dla Seniora przygotowany przez Macieja"},
                new Course(){CourseId=4, Author = "Paweł Senior", Title="Kurs ASP SR", CategoryId = 1, Price = 750, Bestseller = false, FileIcon = "asp4.png", DateAdd = DateTime.Now, ShortDescription="ASP4", Description = "2 Kurs dla Seniora przygotowany przez Macieja"},

                new Course(){CourseId=5, Author = "Michał Junior", Title="Kurs JAVA JR", CategoryId = 2, Price = 40, Bestseller = true, FileIcon = "java1.png", DateAdd = DateTime.Now, ShortDescription="JAVA1", Description = "Kurs dla Jurniora przygotowany przez Michała"},
                new Course(){CourseId=6, Author = "Adam Regular", Title="Kurs JAVA MID", CategoryId = 2, Price = 270, Bestseller = false, FileIcon = "java2.png", DateAdd = DateTime.Now, ShortDescription="JAVA2", Description = "Kurs dla Regulara przygotowany przez Adama"},

                new Course(){CourseId=7, Author = "Michał Junior", Title="Kurs PHP JR", CategoryId = 3, Price = 40, Bestseller = false, FileIcon = "php1.png", DateAdd = DateTime.Now, ShortDescription="PHP1", Description = "Kurs dla Jurniora przygotowany przez Michała"},
                new Course(){CourseId=8, Author = "Adam Regular", Title="Kurs PHP MID", CategoryId = 3, Price = 270, Bestseller = true, FileIcon = "php2.png", DateAdd = DateTime.Now, ShortDescription="PHP2", Description = "Kurs dla Regulara przygotowany przez Adama"},

                new Course(){CourseId=9, Author = "Michał Junior", Title="Kurs HTML JR", CategoryId = 4, Price = 40, Bestseller = true, FileIcon = "html1.png", DateAdd = DateTime.Now, ShortDescription="HTML1", Description = "Kurs dla Jurniora przygotowany przez Michała"},
                new Course(){CourseId=10, Author = "Adam Regular", Title="Kurs HTML MID", CategoryId = 4, Price = 270, Bestseller = false, FileIcon = "html2.png", DateAdd = DateTime.Now, ShortDescription="HTML2", Description = "Kurs dla Regulara przygotowany przez Adama"},
                new Course(){CourseId=11, Author = "Maciej Senior", Title="Kurs HTML SR", CategoryId = 4, Price = 510, Bestseller = false, FileIcon = "html3.png", DateAdd = DateTime.Now, ShortDescription="HTML3", Description = "Kurs dla Seniora przygotowany przez Macieja"},

                new Course(){CourseId=12, Author = "Michał Junior", Title="Kurs CSS JR", CategoryId = 5, Price = 40, Bestseller = false, FileIcon = "css1.png", DateAdd = DateTime.Now, ShortDescription="CSS1", Description = "Kurs dla Jurniora przygotowany przez Michała"},
                new Course(){CourseId=13, Author = "Adam Regular", Title="Kurs CSS MID", CategoryId = 5, Price = 270, Bestseller = false, FileIcon = "css2.png", DateAdd = DateTime.Now, ShortDescription="CSS2", Description = "Kurs dla Regulara przygotowany przez Adama"},
                new Course(){CourseId=14, Author = "Maciej Senior", Title="Kurs CSS SR", CategoryId = 5, Price = 510, Bestseller = true, FileIcon = "css3.png", DateAdd = DateTime.Now, ShortDescription="CSS3", Description = "Kurs dla Seniora przygotowany przez Macieja"},

                new Course(){CourseId=15, Author = "Michał Junior", Title="Kurs XML JR", CategoryId = 6, Price = 40, Bestseller = false, FileIcon = "xml1.png", DateAdd = DateTime.Now, ShortDescription="XML1", Description = "Kurs dla Jurniora przygotowany przez Michała"},

                new Course(){CourseId=16, Author = "Michał Junior", Title="Kurs C# JR", CategoryId = 7, Price = 40, Bestseller = true, FileIcon = "c1.png", DateAdd = DateTime.Now, ShortDescription="C#1", Description = "Kurs dla Jurniora przygotowany przez Michała"},
                new Course(){CourseId=17, Author = "Adam Regular", Title="Kurs C# MID", CategoryId = 7, Price = 270, Bestseller = false, FileIcon = "c2.png", DateAdd = DateTime.Now, ShortDescription="C#2", Description = "Kurs dla Regulara przygotowany przez Adama"},
                new Course(){CourseId=18, Author = "Maciej Senior", Title="Kurs C# SR", CategoryId = 7, Price = 510, Bestseller = false, FileIcon = "c3.png", DateAdd = DateTime.Now, ShortDescription="C#3", Description = "Kurs dla Seniora przygotowany przez Macieja"}

            };
            courses.ForEach(c => context.Courses.AddOrUpdate(c));
            context.SaveChanges();
        }

        public static void SeedUsers(CoursesContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            const string name = "admin@sklep.pl";
            const string password = "Admin.10";
            const string roleName = "Admin";

            var user = userManager.FindByName(name);

            // uworzenie uzytkownika admin
            if (user == null)
            {
                user = new ApplicationUser { UserName = name, Email = name, UserData = new UserData() };
                var result = userManager.Create(user, password);
            }

            // utworzenie roli Admin
            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                var roleResult = roleManager.Create(role);
            }

            // dodanie usera admin do roli Admin
            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(user.Id, role.Name);
            }
        }

    }
}