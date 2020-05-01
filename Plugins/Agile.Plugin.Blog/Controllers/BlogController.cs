using Agile.Core;
using Agile.Data;
using Agile.Models.Infrastructure;
using Agile.Plugin.Blog.Domain;
using Agile.Plugin.Blog.Models;
using Agile.Services.Menus;
using Agile.Web.Framework;
using Agile.Web.Framework.Controllers;
using Microsoft.AspNetCore.Mvc;
using Plugin.Blog.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Agile.Plugin.Blog.Controllers
{
    [MenuAttribute(MenuType.Page, "插件系统|博客插件|前端管理|博客首页", "/admin/blog/index")]
    public class BlogController : BasePluginController
    {
        public IActionResult Index(string type)
        {
            return View("~/Plugins/Blog/Views/Blog/Index.cshtml");
        }
    }
}
