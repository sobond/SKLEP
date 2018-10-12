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
                name: "StaticPages",
                url: "pages/{name}.html",
                defaults: new { controller = "Home", action = "StaticPages" }
            );

            routes.MapRoute(
                name: "CoursesList",
                url: "Category/{name}",
                defaults: new { Controller = "Courses", Action = "List" }
            );

            routes.MapRoute(
                name: "CoursesDatails",
                url: "Course-{id}",
                defaults: new { Controller = "Courses", Action = "Details" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
