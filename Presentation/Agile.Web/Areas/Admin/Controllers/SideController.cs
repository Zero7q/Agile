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
    [MenuAttribute(MenuType.Hidden)]
    public class SideController : BasePluginController
    {
        private readonly IMenuService _menuService;
        public SideController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [PermissionAttribute("view")]
        public IActionResult GetData()
        {
            var result = _menuService.GetMenus();

            return Success(result);
        }
    }
}