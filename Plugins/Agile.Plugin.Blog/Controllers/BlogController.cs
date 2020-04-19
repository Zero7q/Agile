using Agile.Core;
using Agile.Web.Framework;
using Agile.Web.Framework.Attributes;
using Agile.Web.Framework.Controllers;
using Microsoft.AspNetCore.Mvc;
using Plugin.Blog.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Plugin.Blog.Controllers
{
    [MenuAttribute("插件系统|博客首页", "layui-icon layui-icon-home", "/admin/blog/index")]
    public class BlogController : BasePluginController
    {
        public IActionResult Index(string type)
        {
            //测试插件调用外部dll
            //string result = BlogService.Show();

            if (string.IsNullOrWhiteSpace(type))
            {
                throw new ArgumentNullException(nameof(type));
            }

            try
            {
                Convert.ToInt32(type);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                throw new AgileException(nameof(type));
            }

            return View("~/Plugins/Blog/Views/Blog/Index.cshtml");
        }
    }
}
