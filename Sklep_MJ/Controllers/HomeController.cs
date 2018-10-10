using Sklep_MJ.DAL;
using Sklep_MJ.Models;
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
            return View();
        }

        public ActionResult StaticPages(string name)
        {
            return View(name);
        }
    }
}