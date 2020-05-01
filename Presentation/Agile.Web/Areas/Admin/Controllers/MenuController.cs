using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Agile.Core.Domain;
using Agile.Models.Infrastructure;
using Agile.Models.ViewModels;
using Agile.Services.Menus;
using Agile.Web.Framework.Controllers;
using DapperExtensions;
using Microsoft.AspNetCore.Mvc;

namespace Agile.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 菜单控制器
    /// </summary>
    [MenuAttribute(MenuType.Page, "系统管理|菜单管理", "/admin/menu/list")]
    public class MenuController : BasePluginController
    {
        private readonly IMenuService _menuService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="menuService"></param>
        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        /// <summary>
        /// 菜单列表
        /// </summary>
        /// <returns></returns>
        [PermissionAttribute("view")]
        public IActionResult List()
        {
            var model = new SysMenuViewModel();
            model.ParentSelectItems = _menuService.ParentSelectItems();
            return View(model);
        }

        /// <summary>
        /// 获取列表数据
        /// </summary>
        /// <returns></returns>
        [PermissionAttribute("view")]
        public IActionResult GetSideData()
        {
            var result = _menuService.GetMenus();

            return Success(result);
        }

        /// <summary>
        /// 获取菜单侧边栏列表数据
        /// </summary>
        /// <returns></returns>
        [PermissionAttribute("view")]
        public IActionResult GetTreeData()
        {
            var result = _menuService.GetTreeMenus();

            return Success(result);
        }
    }
}