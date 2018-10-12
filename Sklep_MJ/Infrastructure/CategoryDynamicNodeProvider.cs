using MvcSiteMapProvider;
using Sklep_MJ.DAL;
using Sklep_MJ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sklep_MJ.Infrastructure
{
    public class CategoryDynamicNodeProvider : DynamicNodeProviderBase
    {
        private CoursesContext db = new CoursesContext();

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode nodee)
        {
            var returnValue = new List<DynamicNode>();
            foreach (Category category in db.Categories)
            {
                DynamicNode node = new DynamicNode();
                node.Title = category.Name;
                node.Key = "Category_" + category.CategoryId;
                node.RouteValues.Add("name", category.Name);
                returnValue.Add(node);
            }


            return returnValue;
        }
    }
}