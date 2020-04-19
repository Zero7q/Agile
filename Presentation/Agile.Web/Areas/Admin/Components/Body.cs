using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agile.Web.Areas.Admin.Components
{
    public class Body : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
