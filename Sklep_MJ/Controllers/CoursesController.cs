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
        public ActionResult List(string name)
        {
            var category = db.Categories.Include("Courses").Where(k => k.Name.ToUpper() == name.ToUpper()).Single();
            var courses = category.Courses.ToList();
            return View(courses);
        }

        public ActionResult Details(string id)
        {
            var course = db.Courses.Find(int.Parse(id));
            return View(course);
        }

        [ChildActionOnly]
        public ActionResult CategoriesMenu()
        {
            var categories = db.Categories.ToList();
            return PartialView("_CategoriesMenu", categories);
        }
    }
}