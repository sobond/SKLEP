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
            Category category = new Category
            {
                Name = "asp.net mvc",
                FileIcon = "aspNetMvc.png",
                Description = "opis"
            };

            //db.Categories.Add(category);
            //db.SaveChanges();
            return View();
        }
    }
}