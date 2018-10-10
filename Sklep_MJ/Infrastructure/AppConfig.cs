using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Sklep_MJ.Infrastructure
{
    public class AppConfig
    {
        private static string _categoriesIconsFolder = ConfigurationManager.AppSettings["CategoriesIcons"];
        private static string _coursesIconsFolder = ConfigurationManager.AppSettings["CoursesIcons"];

        public static string CategoriesIconsFolder
        {
            get
            {
                return _categoriesIconsFolder;
            }
        }

        public static string CoursesIconsFolder
        {
            get
            {
                return _coursesIconsFolder;
            }
        }

    }
}