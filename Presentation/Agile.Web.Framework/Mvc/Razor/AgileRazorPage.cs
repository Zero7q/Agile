using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Agile.Web.Framework.Mvc.Razor
{
    public abstract class AgileRazorPage<TModel> : RazorPage<TModel>
    {
        public string AgileFullUrl
        {
            get
            {
                if (string.IsNullOrWhiteSpace(AgileArea))
                {
                    return $"/{AgileController}/{AgileAction}";
                }
                return $"/{AgileArea}/{AgileController}/{AgileAction}";
            }
        }

        public string AgileFormatUrl(string action)
        {
            return $"/{AgileArea}/{AgileController}/{action}";
        }

        public string AgileArea
        {
            get
            {
                return ViewContext.RouteData.Values["area"].ToString();
            }
        }

        public string AgileController
        {
            get
            {
                return ViewContext.RouteData.Values["controller"].ToString();
            }
        }

        public string AgileAction
        {
            get
            {
                return ViewContext.RouteData.Values["action"].ToString();
            }
        }
    }

    public abstract class AgileRazorPage : AgileRazorPage<dynamic>
    {

    }
}
