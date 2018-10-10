using Sklep_MJ.DAL;
using Sklep_MJ.Models;
using Sklep_MJ.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sklep_MJ.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private CoursesContext db = new CoursesContext();

        public ActionResult Index()
        {
            var categories = db.Categories.ToList();
            var news = db.Courses.Where(a => !a.Hidden).OrderByDescending(a => a.DateAdd).Take(3).ToList();
            var bestsellers = db.Courses.Where(a => !a.Hidden && a.Bestseller).OrderBy(a => Guid.NewGuid()).Take(3).ToList();

            var vm = new HomeViewModel()
            {
                BestSellers = bestsellers,
                Categories = categories,
                News = news
            };
            return View(vm);
        }

        public ActionResult StaticPages(string name)
        {
            return View(name);
        }
    }
}