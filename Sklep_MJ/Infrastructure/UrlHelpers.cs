using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sklep_MJ.Infrastructure
{
    public static class UrlHelpers
    {
        public static string CategoriesIconsPath (this System.Web.Mvc.UrlHelper helper, string iconName)
        {
            var categoriesIconsFolder = AppConfig.CategoriesIconsFolder;
            var path = Path.Combine(categoriesIconsFolder, iconName);
            var pathHelper = helper.Content(path);
            return pathHelper;
        }

        public static string CoursesIconsPath(this System.Web.Mvc.UrlHelper helper, string iconName)
        {
            var coursesIconsFolder = AppConfig.CoursesIconsFolder;
            var path = Path.Combine(coursesIconsFolder, iconName);
            var pathHelper = helper.Content(path);
            return pathHelper;
        }
    }
}