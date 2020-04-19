using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agile.Web.Framework.ViewLocationExpander
{
    public class AgileViewLocationExpander : IViewLocationExpander
    {
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            viewLocations = new[] {
                "/Areas/Admin/{2}/Views/{1}/{0}.cshtml",
                "/Areas/Admin/{2}/Views/Shared/{0}.cshtml",
                "/Areas/Admin/Views/Shared/{0}.cshtml",
            }.Concat(viewLocations);
            return viewLocations;
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {

        }
    }
}
