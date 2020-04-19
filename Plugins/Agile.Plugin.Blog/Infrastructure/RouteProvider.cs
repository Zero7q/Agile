using Agile.Web.Framework.Mvc.Routing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Plugin.Blog.Infrastructure
{
    public class RouteProvider : IRouteProvider
    {
        /// <summary>
        /// Register routes
        /// </summary>
        /// <param name="endpointRouteBuilder">Route builder</param>
        public void RegisterRoutes(IEndpointRouteBuilder endpointRouteBuilder)
        {
            //override some of default routes in Admin area
            //endpointRouteBuilder.MapControllerRoute("Plugin.Tax.Avalara.Tax.Categories", "Admin/Tax/Categories",
            //    new { controller = "OverriddenTax", action = "Categories", area = AreaNames.Admin });


            endpointRouteBuilder.MapControllerRoute("Plugin.Blog.Index", "Admin/Blog/Index",
                new { controller = "Blog", action = "Index", area = "Admin" });
        }

        /// <summary>
        /// Gets a priority of route provider
        /// </summary>
        public int Priority => 1; //set a value that is greater than the default one in Nop.Web to override routes
    }
}
