using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agile.Services.Menus;
using Agile.Web.Framework.Controllers;
using DapperExtensions;
using Microsoft.AspNetCore.Mvc;

namespace Agile.Web.Areas.Admin.Controllers
{
    [MenuAttribute("系统设置|菜单管理", "layui-icon layui-icon-home", "/admin/menu/index")]
    public class MenuController : BasePluginController
    {
        private readonly IMenuService _menuService;
        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Side()
        {
            var menuViewModel = _menuService.GetMenus();

            return Success(menuViewModel);
        }
    }
}