using NLog;
using Sklep_MJ.DAL;
using Sklep_MJ.Infrastructure;
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
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public ActionResult Index()
        {
            logger.Info("Jesteś na stronie głównej");
            //throw new Exception("Blad wywolany recznie");
            ICacheProvider cache = new DefaultCacheProvider();

            List<Category> categories;
            if (cache.IsSet(Const.CategoriesCacheKey))
            {
                categories = cache.Get(Const.CategoriesCacheKey) as List<Category>;
            }
            else
            {
                categories = db.Categories.ToList();
                cache.Set(Const.CategoriesCacheKey, categories, 60);
            }


            List<Course> news;
            if (cache.IsSet(Const.NewsCacheKey))
            {
                news = cache.Get(Const.NewsCacheKey) as List<Course>;
            }
            else
            {
                news = db.Courses.Where(a => !a.Hidden).OrderByDescending(a => a.DateAdd).Take(3).ToList();
                cache.Set(Const.NewsCacheKey, news, 60);
            }

            List<Course> bestsellers;
            if (cache.IsSet(Const.BestsellersCacheKey))
            {
                bestsellers = cache.Get(Const.BestsellersCacheKey) as List<Course>;
            }
            else
            {
                bestsellers = db.Courses.Where(a => !a.Hidden && a.Bestseller).OrderBy(a => Guid.NewGuid()).Take(3).ToList();
                cache.Set(Const.BestsellersCacheKey, bestsellers, 60);
            }


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