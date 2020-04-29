using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agile.Models.Menus.Infrastructure;
using Agile.Models.Permissions.Infrastructure;
using Agile.Services.Menus;
using Agile.Web.Framework.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Agile.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 菜单侧边栏控制器
    /// </summary>
    [MenuAttribute(MenuType.Hidden)]
    public class SideController : BasePluginController
    {

        private readonly IMenuService _menuService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="menuService"></param>
        public SideController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        [PermissionAttribute("view")]
        public IActionResult GetData()
        {
            var result = _menuService.GetTreeMenus();

            return Success(result);
        }
    }
}