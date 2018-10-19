using Sklep_MJ.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sklep_MJ.Controllers
{
    public class CoursesController : Controller
    {
        private CoursesContext db = new CoursesContext();
        // GET: Courses
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List(string name, string searchQuery=null)
        {
            var category = db.Categories.Include("Courses").Where(k => k.Name.ToUpper() == name.ToUpper()).Single();
            var courses = category.Courses.Where(a => (searchQuery == null || a.Title.ToLower().Contains(searchQuery.ToLower()) || a.Author.ToLower().Contains(searchQuery.ToLower())) && !a.Hidden);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_CoursesList", courses);
            }
            return View(courses);
        }

        public ActionResult Details(string id)
        {
            var course = db.Courses.Find(int.Parse(id));
            return View(course);
        }

        [ChildActionOnly]
        //atybut OutputCache pozwala na zmiane pobierania danych z cache zamiast z bazy danych (poprawa wydajności)
        [OutputCache(Duration = 60000)]
        public ActionResult CategoriesMenu()
        {
            
            var categories = db.Categories.ToList();
            return PartialView("_CategoriesMenu", categories);
        }

        public ActionResult CoursesTips(string term)
        {
            var courses = db.Courses.Where(a => !a.Hidden && a.Title.ToLower().Contains(term.ToLower())).Take(5).Select(a => new { label = a.Title });

            return Json(courses, JsonRequestBehavior.AllowGet);
        }
    }
}