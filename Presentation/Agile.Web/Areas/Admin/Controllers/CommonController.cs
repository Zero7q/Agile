using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agile.Web.Framework.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Agile.Web.Areas.Admin.Controllers
{
    public class CommonController : BasePluginController
    {
        public IActionResult Error()
        {
            return View();
        }

        public IActionResult NotFoundPage()
        {
            return View();
        }
    }
}