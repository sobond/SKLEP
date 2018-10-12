using MvcSiteMapProvider;
using Sklep_MJ.DAL;
using Sklep_MJ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sklep_MJ.Infrastructure
{
    public class CourseDetailsNodeProvider : DynamicNodeProviderBase
    {
        private CoursesContext db = new CoursesContext();

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode nodee)
        {
            var returnValue = new List<DynamicNode>();
            foreach (Course course in db.Courses)
            {
                DynamicNode node = new DynamicNode();
                node.Title = course.Title;
                node.Key = "Course_" + course.CourseId;
                node.ParentKey = "Category_" + course.CategoryId;
                node.RouteValues.Add("id", course.CourseId);
                returnValue.Add(node);
            }


            return returnValue;
        }
    }
}