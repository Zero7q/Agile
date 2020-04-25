using Agile.Core;
using Agile.Data;
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
    [MenuAttribute("一级菜单|一级菜单|三级菜单|四级菜单", "layui-icon layui-icon-home", "/admin/blog/index")]
    public class BlogController : BasePluginController
    {
        public IActionResult Index(string type)
        {
            return View("~/Plugins/Blog/Views/Blog/Index.cshtml");
        }
    }
}
