using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agile.Core.Domain;
using Agile.Models.Menus.Infrastructure;
using Agile.Models.Menus.ViewModel;
using Agile.Models.Permissions.Infrastructure;
using Agile.Services.Menus;
using Agile.Web.Framework.Controllers;
using DapperExtensions;
using Microsoft.AspNetCore.Mvc;

namespace Agile.Web.Areas.Admin.Controllers
{
    [MenuAttribute(MenuType.Display, "系统设置|菜单管理", "/admin/menu/list")]
    public class MenuController : BasePluginController
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [PermissionAttribute("view")]
        public IActionResult List()
        {
            var model = new MenuViewModel();
            model.ParentSelectItems = _menuService.ParentSelectItems();
            return View(model);
        }

        [PermissionAttribute("view")]
        public IActionResult GetData()
        {
            var result = _menuService.GetTreeMenus();

            return Success(result);
        }
    }
}