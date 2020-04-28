using Agile.Models.Menus.Infrastructure;
using Agile.Services.Menus;
using Agile.Web.Framework.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Plugin.Blog.Controllers
{
    [MenuAttribute(MenuType.Display, "插件系统|博客插件|后端管理|类别管理", "/admin/category/index")]
    public class CategoryController : BasePluginController
    {
        public IActionResult Index()
        {
            return View("~/Plugins/Blog/Views/Category/Index.cshtml");
        }
    }
}
