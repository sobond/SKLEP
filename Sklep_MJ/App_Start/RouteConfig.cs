﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Sklep_MJ
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "CoursesDatails",
               url: "course-{id}.html",
               defaults: new { controller = "Courses", action = "Details" }
           );

            routes.MapRoute(
                name: "CoursesList",
                url: "category/{name}",
                defaults: new { controller = "Courses", action = "List" }
            );

            routes.MapRoute(
                name: "StaticPages",
                url: "pages/{name}.html",
                defaults: new { controller = "Home", action = "StaticPages" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
